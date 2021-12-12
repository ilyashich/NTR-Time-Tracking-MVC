using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeReporter.Models;
using TimeReporter.Models.Repository;


namespace TimeReporter.Controllers
{
    public class ManageController : Controller
    {
        private readonly TimeReporterContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ReportRepository _reportRepository;
        private readonly ActivityRepository _activityRepository;

        public ManageController(TimeReporterContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _db = context;
            _reportRepository = new ReportRepository(_db);
            _activityRepository = new ActivityRepository(_db);
        }
        // GET
        public IActionResult Index()
        {
            ManageOption selectedOption = new ManageOption
            {
                SelectedWorkerId = SessionUser.GetSessionUser(_httpContextAccessor, _db).WorkerId
            };

            if (TempData["selectedMonth"] != null)
            {
                selectedOption.SelectedMonth = (string)TempData["selectedMonth"];
            }
            
            if (TempData["selectedYear"] != null)
            {
                selectedOption.SelectedYear = (int)TempData["selectedYear"];
            }

            selectedOption.Projects = _db.Activities
                .Where(activity => activity.Worker.WorkerId == selectedOption.SelectedWorkerId).ToList();
            
            if (selectedOption.Projects.Any())
            {
                selectedOption.SelectedProjectId = selectedOption.Projects[0].ActivityId;
            }

            if (TempData["selectedProjectId"] != null)
            {
                selectedOption.SelectedProjectId = (int)TempData["selectedProjectId"];
            }

            Activity activity =
                _db.Activities.SingleOrDefault(activity => activity.ActivityId == selectedOption.SelectedProjectId);

            if (activity != null)
            {
                var workers = _db.Workers.Include(worker => worker.Entries).ToList();
                selectedOption.ProjectWorkers = workers.Where(worker =>
                        worker.Entries.Exists(entry => entry.ActivityId == selectedOption.SelectedProjectId))
                    .Select(worker => worker).ToList();
                ViewBag.budget = activity.Budget;
                ViewBag.isActive = activity.Active;
            }
            else
            {
                selectedOption.ProjectWorkers = new List<Worker>();
            }
            
            foreach (var worker in selectedOption.ProjectWorkers)
            {
                Report report = _reportRepository.GetReport(worker.WorkerId, selectedOption.SelectedMonth, selectedOption.SelectedYear);
                if (report != null)
                {
                    selectedOption.IsFrozen.Add(report.Frozen);
                    AcceptedTime accepted = _reportRepository.GetAccepted(report, selectedOption.SelectedProjectId);
                    if (accepted != null)
                    {
                        selectedOption.AcceptedTime.Add(accepted.Time);
                    }
                    else
                    {
                        selectedOption.AcceptedTime.Add(0);
                    }

                    int timeSum = report.Entries.Where(entry => entry.ActivityId == selectedOption.SelectedProjectId)
                        .Sum(entry => entry.Time);
                    selectedOption.SubmittedTime.Add(timeSum);
                }
            }
            return View(selectedOption);
        }

        [HttpGet]
        public ActionResult CreateProjectModal(string selectedMonth, int selectedYear, int selectedProjectId)
        {
            Activity activity = new Activity();
            
            ViewBag.selectedMonth = selectedMonth;
            ViewBag.selectedYear = selectedYear;
            ViewBag.selectedProjectId = selectedProjectId;

            return PartialView(activity);
        }

        [HttpPost]
        public ActionResult ModalAction(string selectedMonth, int selectedYear, int selectedProjectId,
            string code, string name, int budget)
        {
            Worker selectedWorker = SessionUser.GetSessionUser(_httpContextAccessor, _db);
            Activity newActivity = new Activity()
            {
                Code = code,
                WorkerId = selectedWorker.WorkerId,
                Name = name,
                Budget = budget,
                Active = true
            };

            if (_activityRepository.AddNewActivity(newActivity))
            {
                TempData["selectedMonth"] = selectedMonth;
                TempData["selectedYear"] = selectedYear;
                TempData["selectedProjectId"] = newActivity.ActivityId;
                return RedirectToAction("Index");
            }
            
            TempData["Alert"] = "Project with name " + code + " already exists!";
            TempData["selectedMonth"] = selectedMonth;
            TempData["selectedYear"] = selectedYear;
            TempData["selectedProjectId"] = selectedProjectId;
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public ActionResult SelectMonth(string selectedMonth, int selectedYear, int selectedProjectId)
        {
            TempData["selectedMonth"] = selectedMonth;
            TempData["selectedYear"] = selectedYear;
            TempData["selectedProjectId"] = selectedProjectId;
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult SelectYear(string selectedMonth, int selectedYear, int selectedProjectId)
        {
            TempData["selectedMonth"] = selectedMonth;
            TempData["selectedYear"] = selectedYear;
            TempData["selectedProjectId"] = selectedProjectId;
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult SelectProject(string selectedMonth, int selectedYear, int selectedProjectId)
        {
            TempData["selectedMonth"] = selectedMonth;
            TempData["selectedYear"] = selectedYear;
            TempData["selectedProjectId"] = selectedProjectId;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CloseProject(string selectedMonth, int selectedYear, int selectedProjectId)
        {
            if (IsProjectActive(selectedProjectId) < 0)
            {
                TempData["Alert"] = "This project doesn't exist";
                TempData["selectedMonth"] = selectedMonth;
                TempData["selectedYear"] = selectedYear;
                TempData["selectedProjectId"] = selectedProjectId;
                return RedirectToAction("Index");
            }
            if (IsProjectActive(selectedProjectId) > 0)
            {
                TempData["Alert"] = "This project is already closed";
                TempData["selectedMonth"] = selectedMonth;
                TempData["selectedYear"] = selectedYear;
                TempData["selectedProjectId"] = selectedProjectId;
                return RedirectToAction("Index");
            }

            _db.Activities.Single(activity => activity.ActivityId == selectedProjectId).Active = false;
            _db.SaveChanges();

            TempData["Success"] = "Successfully closed project";
            TempData["selectedMonth"] = selectedMonth;
            TempData["selectedYear"] = selectedYear;
            TempData["selectedProjectId"] = selectedProjectId;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AcceptTime(string selectedMonth, int selectedYear, int selectedProjectId, 
             int workerId, int time)
        {
            if (IsProjectActive(selectedProjectId) > 0)
            {
                TempData["Alert"] = "Can't accept because this project is closed";
                TempData["selectedMonth"] = selectedMonth;
                TempData["selectedYear"] = selectedYear;
                TempData["selectedProjectId"] = selectedProjectId;
                return RedirectToAction("Index");
            }

            RecalculateBudget(workerId, selectedMonth, selectedYear, selectedProjectId, time);
            AcceptWorker(workerId, selectedMonth, selectedYear, selectedProjectId, time);
            
            TempData["Success"] = "Successfully accepted time";
            TempData["selectedMonth"] = selectedMonth;
            TempData["selectedYear"] = selectedYear;
            TempData["selectedProjectId"] = selectedProjectId;
            return RedirectToAction("Index");
        }

        private void RecalculateBudget(int workerId, string selectedMonth, int selectedYear, int selectedProjectId, int time)
        {
            Report report = _reportRepository.GetReport(workerId, selectedMonth, selectedYear);
            
            AcceptedTime acceptedTime = report.Accepted.SingleOrDefault(accepted => accepted.ActivityId == selectedProjectId);

            int timeChange;

            if (acceptedTime != null)
            {
                timeChange = acceptedTime.Time - time;
            }
            else
            {
                timeChange = -time;
            }

            Activity activity = _db.Activities.SingleOrDefault(accepted => accepted.ActivityId == selectedProjectId);
            
            if (activity != null)
            {
                activity.Budget += timeChange;
            }

            _db.SaveChanges();
        }

        private void AcceptWorker(int workerId, string selectedMonth, int selectedYear, int selectedProjectId, int time)
        {
            Report report = _reportRepository.GetReport(workerId, selectedMonth, selectedYear);
            AcceptedTime acceptedTime = report.Accepted.SingleOrDefault(accepted => accepted.ActivityId == selectedProjectId);
            if (acceptedTime != null)
            {
                acceptedTime.Time = time;
            }
            else
            {

                report.Accepted.Add(
                    new AcceptedTime()
                    {
                        ActivityId = selectedProjectId,
                        Time = time,
                        ReportId = report.ReportId,
                        WorkerId = workerId
                    });
            }

            _db.SaveChanges();
        }

        private int IsProjectActive(int selectedProjectId)
        {
            var selectedProject = _db.Activities.SingleOrDefault(activity => activity.ActivityId == selectedProjectId);
            if (selectedProject == null)
                return -1;
            return selectedProject.Active switch
            {
                true => 0,
                false => 1
            };
        }
    }
}