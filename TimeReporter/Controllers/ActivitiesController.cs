using System;
using System.Collections.Generic;
using SysActivity = System.Diagnostics.Activity;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeReporter.Models;
using TimeReporter.Models.Repository;

namespace TimeReporter.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly TimeReporterContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ReportRepository _reportRepository;

        public ActivitiesController(TimeReporterContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _db = context;
            _reportRepository = new ReportRepository(_db);
        }

        public ActionResult Index()
        {
            Option selectedOption = new Option
            {
                SelectedWorker = SessionUser.GetSessionUser(_httpContextAccessor, _db)
            };

            if (TempData["selectedDate"] != null)
            {
                selectedOption.SelectedDate = (DateTime)TempData["selectedDate"];
            }

            Report report = _reportRepository.GetReport(selectedOption.SelectedWorker, selectedOption.SelectedDate);


            selectedOption.Entries = new List<Entry>();
            
            ViewBag.accepted = new List<AcceptedTime>();
            List<string> managers = new List<string>();
            List<string> projects = new List<string>();
            List<int> projectSum = new List<int>();
            ViewBag.isFrozen = true;

            if(report != null)
            {
                ViewBag.accepted = report.Accepted;
                ViewBag.isFrozen = report.Frozen;
                selectedOption.Entries = _reportRepository.GetDayEntries(selectedOption.SelectedWorker, selectedOption.SelectedDate);
                foreach (var accept in report.Accepted)
                {
                    managers.Add(accept.Activity.Worker.Name);
                }
                
                projects.AddRange(report.Entries.Select(entry => entry.Activity.Code).Distinct());

                foreach (var project in projects)
                {
                    projectSum.Add(report.Entries.Where(entry => entry.Activity.Code.Equals(project)).Sum(entry => entry.Time));
                }
            }

            
            ViewBag.managers = managers;
            ViewBag.projects = projects;
            ViewBag.projectSum = projectSum;

            return View(selectedOption);
        }

        [HttpPost]
        public ActionResult SelectDate(DateTime selectedDate)
        {
            TempData["selectedDate"] = selectedDate;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SubmitMonth(DateTime selectedDate)
        {
            Worker selectedWorker = SessionUser.GetSessionUser(_httpContextAccessor, _db);
            Report report = _reportRepository.GetReport(selectedWorker, selectedDate);
            if (report == null)
            {
                TempData["Alert"] = "Can't submit because report for this month doesn't exist";
                TempData["selectedDate"] = selectedDate;
                return RedirectToAction("Index");
            }

            if (report.Frozen)
            {
                TempData["Alert"] = "This month is already submitted";
                TempData["selectedDate"] = selectedDate;
                return RedirectToAction("Index");
            }

            report.Frozen = true;

            _db.SaveChanges();
            TempData["Success"] = "Successfully submitted month: " + System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(selectedDate.Month);
            TempData["selectedDate"] = selectedDate;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(DateTime selectedDate, int deleteIdx)
        { 
            Worker selectedWorker = SessionUser.GetSessionUser(_httpContextAccessor, _db);
            Report report = _reportRepository.GetReport(selectedWorker, selectedDate);
            if(report.Frozen ||  !IsProjectActive(selectedDate, deleteIdx))
            {
                TempData["Alert"] = "Month is frozen or project is not active";
                TempData["selectedDate"] = selectedDate;
                return RedirectToAction("Index");
            }

            _db.Remove(report.Entries[deleteIdx]);
            _db.SaveChanges();
            TempData["Success"] = "Successfully deleted entry";
            TempData["selectedDate"] = selectedDate;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EntryModal(DateTime selectedDate, int idx)
        {
            Worker selectedWorker = SessionUser.GetSessionUser(_httpContextAccessor, _db);

            Entry entry = idx >= 0 ? _reportRepository.GetDayEntries(selectedWorker, selectedDate)[idx] : new Entry();

            ViewBag.selectedSurname = selectedWorker.Name;
            ViewBag.selectedDate = selectedDate;
            ViewBag.idx = idx;
            ViewBag.codes = _db.Activities.Select(activity => activity.Code).ToList();

            return PartialView(entry);
        }

        [HttpPost]
        public ActionResult ModalAction(DateTime selectedDate, int idx,
            string code, string subcode, int time, string description)
        {
            Worker selectedWorker = SessionUser.GetSessionUser(_httpContextAccessor, _db);
            if (_reportRepository.GetReport(selectedWorker, selectedDate) == null
                && IsProjectActive(code)
                && selectedDate.Month == DateTime.Now.Month
                && selectedDate.Year == DateTime.Now.Year)
            {
                Report newReport = new Report {Date = selectedDate, Frozen = false, WorkerId = selectedWorker.WorkerId};
                _db.Reports.Add(newReport);
                _db.SaveChanges();
            }
            else if (selectedDate.Month != DateTime.Now.Month || selectedDate.Year != DateTime.Now.Year)
            {
                TempData["Alert"] = "Entries can be added only to current month";
                TempData["selectedDate"] = selectedDate;
                return RedirectToAction("Index");
            }
            else if (!IsProjectActive(code))
            {
                TempData["Alert"] = "Project " + code + " is not active";
                TempData["selectedDate"] = selectedDate;
                return RedirectToAction("Index");
                
            }
            
            Report report = _reportRepository.GetReport(selectedWorker, selectedDate);

            if(report.Frozen)
            {
                TempData["Alert"] = "Month is frozen";
                TempData["selectedDate"] = selectedDate;
                return RedirectToAction("Index");
            }

            int activityId = _db.Activities.Where(activity => activity.Code == code)
                                        .Select(activity => activity.ActivityId).Single();
            int subactivityId = _db.Subactivities.Where(subactivity => subactivity.ActivityId == activityId 
                                                                    && subactivity.Code == subcode)
                                                .Select(subactivity => subactivity.SubactivityId)
                                                .SingleOrDefault();
            if (subactivityId == 0)
            {
                var newSubactivity = new Subactivity() {Code = subcode, ActivityId = activityId};
                _db.Subactivities.Add(newSubactivity);
                _db.SaveChanges();
                subactivityId = newSubactivity.SubactivityId;
            }



            if(idx == -1)
            {
                Entry newEntry = new Entry()
                {
                    Date = selectedDate,
                    ActivityId = activityId,
                    SubactivityId = subactivityId,
                    Time = time,
                    Description = description,
                    WorkerId = selectedWorker.WorkerId,
                    ReportId = report.ReportId
                };
                
                _db.Entries.Add(newEntry);
            }
            else
            {
                var editEntry = _reportRepository.GetDayEntries(selectedWorker, selectedDate)[idx];
                editEntry.ActivityId = activityId;
                editEntry.SubactivityId = subactivityId;
                editEntry.Time = time;
                editEntry.Description = description;
            }

            _db.SaveChanges();
            
            TempData["selectedDate"] = selectedDate;
            return RedirectToAction("Index");
        }

        private bool IsProjectActive(DateTime selectedDate, int idx)
        {
            Worker selectedWorker = SessionUser.GetSessionUser(_httpContextAccessor, _db);
            Activity activity = _reportRepository.GetDayEntries(selectedWorker, selectedDate)[idx].Activity;
            return activity != null && activity.Active;
        }

        private bool IsProjectActive(string code)
        {
            Activity activity = _db.Activities.SingleOrDefault(activity1 => activity1.Code == code);
            return activity != null && activity.Active;
        }
    }
}
