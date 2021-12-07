using System;
using System.Collections.Generic;
using SysActivity = System.Diagnostics.Activity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeReporter.Models;

namespace TimeReporter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Option selectedOption = new Option();
            
            Data data = JsonSerde.GetData();

            selectedOption.Surnames = data.Workers.Select(worker => worker.Name).ToList();
            
            return View(selectedOption);
        }
        
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(string selectedSurname)
        {
            HttpContext.Session.SetString(Worker.SessionLogin, selectedSurname);
            return View();
        }
        
        [HttpPost]
        public IActionResult AddNewWorker(string newSurname)
        {
            Data data = JsonSerde.GetData();
            
            List<string> workers = data.Workers.Select(worker => worker.Name).ToList();
            
            if (!workers.Contains(newSurname))
            {
                data.Workers.Add(new Worker(newSurname));
                JsonSerde.SaveDataChanges(data);
            }
            HttpContext.Session.SetString(Worker.SessionLogin, newSurname);
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
