using Microsoft.AspNetCore.Mvc;

namespace petStoreMonitoringApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
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
    }
}
