using System;
using System.Collections.Generic;
using SysActivity = System.Diagnostics.Activity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.EntityFrameworkCore.Extensions;
using TimeReporter.Models;

namespace TimeReporter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly TimeReporterContext _db;

        public HomeController(ILogger<HomeController> logger, TimeReporterContext context)
        {
            _logger = logger;
            _db = context;
        }

        public IActionResult Index()
        {
            Option selectedOption = new Option
            {
                Surnames = _db.Workers.Select(worker => worker.Name).ToList()
            };

            return View(selectedOption);
        }
        
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(string selectedWorker)
        {
            Console.WriteLine(selectedWorker);
            HttpContext.Session.SetString(SessionUser.SessionLogin, selectedWorker);
            return View();
        }
        
        [HttpPost]
        public IActionResult AddNewWorker(string newSurname)
        {
            List<string> workers = _db.Workers.Select(worker => worker.Name).ToList();
            
            if (!workers.Contains(newSurname))
            {
                _db.Workers.Add(new Worker{Name = newSurname});
                _db.SaveChanges();
            }
            HttpContext.Session.SetString(SessionUser.SessionLogin, newSurname);
            return RedirectToAction("Login");
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = SysActivity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
