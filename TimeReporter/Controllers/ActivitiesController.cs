using System;
using System.Collections.Generic;
using System.Data.Entity;
using SysActivity = System.Diagnostics.Activity;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
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
                selectedOption.AllMonthEntries = report.Entries;
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
        public ActionResult Delete(DateTime selectedDate, int entryId)
        { 
            Entry entry = _reportRepository.GetEntryById(entryId);

            if (entry == null)
            {
                TempData["Alert"] = "Can't delete because entry has been deleted";
                TempData["selectedDate"] = selectedDate;
                return RedirectToAction("Index");
            }
            
            Worker selectedWorker = SessionUser.GetSessionUser(_httpContextAccessor, _db);
            Report report = _reportRepository.GetReport(selectedWorker, selectedDate);
            
            if(report.Frozen)
            {
                TempData["Alert"] = "Month is frozen";
                TempData["selectedDate"] = selectedDate;
                return RedirectToAction("Index");
            }
            if(IsProjectActive(entry.ActivityId) > 0)
            {
                TempData["Alert"] = "Project is not active";
                TempData["selectedDate"] = selectedDate;
                return RedirectToAction("Index");
            }
            if(IsProjectActive(entry.ActivityId) < 0)
            {
                TempData["Alert"] = "Project doesn't exist";
                TempData["selectedDate"] = selectedDate;
                return RedirectToAction("Index");
            }

            _db.Remove(entry);
            _db.SaveChanges();
            TempData["Success"] = "Successfully deleted entry";
            TempData["selectedDate"] = selectedDate;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddModal(DateTime selectedDate)
        {
            Worker selectedWorker = SessionUser.GetSessionUser(_httpContextAccessor, _db);

            Entry entry = new Entry();

            ViewBag.selectedSurname = selectedWorker.Name;
            ViewBag.selectedDate = selectedDate;
            ViewBag.codes = _db.Activities.ToList();

            return PartialView(entry);
        }
        
        [HttpPost]
        public ActionResult AddEntry(DateTime selectedDate,
            int activityId, string subcode, int time, string description)
        {
            Worker selectedWorker = SessionUser.GetSessionUser(_httpContextAccessor, _db);
            if (_reportRepository.GetReport(selectedWorker, selectedDate) == null
                && IsProjectActive(activityId) == 0
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
            else if (IsProjectActive(activityId) > 0)
            {
                TempData["Alert"] = "Cannot add because project is not active";
                TempData["selectedDate"] = selectedDate;
                return RedirectToAction("Index");
                
            }
            else if (IsProjectActive(activityId) < 0)
            {
                TempData["Alert"] = "Cannot add because project doesn't exist";
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
            
            var subactivity = _db.Subactivities
                .SingleOrDefault(subactivity => subactivity.ActivityId == activityId && subactivity.Code == subcode);
            int subactivityId;
            if (subactivity == null)
            {
                var newSubactivity = new Subactivity() {Code = subcode, ActivityId = activityId};
                _db.Subactivities.Add(newSubactivity);
                _db.SaveChanges();
                subactivityId = newSubactivity.SubactivityId;
            }
            else
            {
                subactivityId = subactivity.SubactivityId;
            }

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
            _db.SaveChanges();
            
            TempData["selectedDate"] = selectedDate;
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult EditModal(DateTime selectedDate, 
            int entryId, int activityId, string subcode, int time, string description, DateTime timestamp)
        {
            Worker selectedWorker = SessionUser.GetSessionUser(_httpContextAccessor, _db);

            TempData["activityId"] = activityId;
            TempData["subcode"] = subcode;
            TempData["time"] = time;
            TempData["description"] = description;
            
            ViewBag.selectedSurname = selectedWorker.Name;
            ViewBag.selectedDate = selectedDate;
            ViewBag.entryId = entryId;
            ViewBag.timestamp = timestamp;
            ViewBag.codes = _db.Activities.ToList();

            return PartialView();
        }

        [HttpPost]
        public ActionResult EditEntry(DateTime selectedDate, int entryId, string timestamp,
            int activityId, string subcode, int time, string description)
        {
            Entry entry = _reportRepository.GetEntryById(entryId);

            if (entry == null)
            {
                TempData["Alert"] = "Can't edit because entry has been deleted";
                TempData["selectedDate"] = selectedDate;
                return RedirectToAction("Index");
            }

            DateTime newTimestamp = JsonSerializer.Deserialize<DateTime>(timestamp);

            if (DateTime.Compare(entry.Timestamp, newTimestamp) > 0)
            {
                TempData["Alert"] = "Can't edit because entry was already modified. Try again.";
                TempData["selectedDate"] = selectedDate;
                return RedirectToAction("Index");
            }
            
            Worker selectedWorker = SessionUser.GetSessionUser(_httpContextAccessor, _db);
            if (IsProjectActive(activityId) > 0)
            {
                TempData["Alert"] = "Cannot edit because project is not active";
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
            
            var subactivity = _db.Subactivities
                .SingleOrDefault(subactivity => subactivity.ActivityId == activityId && subactivity.Code == subcode);
            int subactivityId;
            if (subactivity == null)
            {
                var newSubactivity = new Subactivity() {Code = subcode, ActivityId = activityId};
                _db.Subactivities.Add(newSubactivity);
                _db.SaveChanges();
                subactivityId = newSubactivity.SubactivityId;
            }
            else
            {
                subactivityId = subactivity.SubactivityId;
            }
            
            var editEntry = _db.Entries.Single(currentEntry => currentEntry.EntryId == entryId);
            editEntry.ActivityId = activityId;
            editEntry.SubactivityId = subactivityId;
            editEntry.Time = time;
            editEntry.Description = description;

            _db.SaveChanges();
            
            TempData["selectedDate"] = selectedDate;
            return RedirectToAction("Index");
        }

        private int IsProjectActive(int activityId)
        {
            Activity activity = _db.Activities.SingleOrDefault(activity1 => activity1.ActivityId == activityId);
            if (activity == null)
                return -1;
            return activity.Active switch
            {
                true => 0,
                false => 1
            };
        }
    }
}
