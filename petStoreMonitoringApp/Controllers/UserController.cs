using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

using petStoreMonitoringApp.Models.ViewModels;
using petStoreMonitoringApp.Models;
using petStoreMonitoringApp.Services;

namespace petStoreMonitoringApp.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class UserController : Controller
    {
        private const string BASE_ADDRESS = "https://se2monitoringwebapi.azurewebsites.net";

        private static readonly HttpClient client = new HttpClient();
        private static JsonSerializerOptions options
            = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        static UserController()
        {
            client.BaseAddress = new Uri(BASE_ADDRESS);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MetricSelect()
        {
            return View();
        }

        //[HttpGet("/Views/Home/ProjectInfo/Business")]
        public async Task<IActionResult> Business()
        {
            var businessMetricsVM = await BusinessDataAggregator.GetDataFromAPI();
            businessMetricsVM = BusinessDataAggregator.AggregateData(businessMetricsVM);

            return View(businessMetricsVM);
        }

        //[HttpGet("/Views/Home/ProjectInfo/Performance")]
        public async Task<IActionResult> Performance()
        {
            var performanceMetricsVM = await PerformanceDataAggregator.GetDataFromAPI();
            performanceMetricsVM = PerformanceDataAggregator.AggregateData(performanceMetricsVM);

            return View(performanceMetricsVM);
        }
    }
}
