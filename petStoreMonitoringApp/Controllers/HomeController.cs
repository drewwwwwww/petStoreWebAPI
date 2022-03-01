using Microsoft.AspNetCore.Mvc;
using petStoreMonitoringApp.Models;
using System.Diagnostics;

namespace petStoreMonitoringApp.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public new IActionResult User()
        {
            return View();
        }

        public new IActionResult MetricSelect()
        {
            return View();
        }

        //[HttpGet("/Views/Home/ProjectInfo/Business")]
        public new IActionResult Business()
        {
            //return View("/Views/Home/ProjectInfo/Business"); //I wanted to get it into a subfolder but couldn't
            return View();
        }

        //[HttpGet("/Views/Home/ProjectInfo/Performance")]
        public new IActionResult Performance()
        {
            //return View("/Views/Home/ProjectInfo/Performance"); //I wanted to get it into a subfolder but couldn't
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}