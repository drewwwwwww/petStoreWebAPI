using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using petStoreMonitoringApp.Models;
using petStoreMonitoringApp.Models.ViewModels;
using System.Diagnostics;

namespace petStoreMonitoringApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
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

        public IActionResult MaintainUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }

        public IActionResult MaintainMetrics()
        {
            return View();
        }

        public IActionResult MaintainProjects()
        {
            return View();
        }

        public IActionResult User()
        {
            return View();
        }

        public IActionResult MetricSelect()
        {
            return View();
        }

        //[HttpGet("/Views/Home/ProjectInfo/Business")]
        public IActionResult Business()
        {
            //return View("/Views/Home/ProjectInfo/Business"); //I wanted to get it into a subfolder but couldn't
            return View();
        }

        //[HttpGet("/Views/Home/ProjectInfo/Performance")]
        public IActionResult Performance()
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