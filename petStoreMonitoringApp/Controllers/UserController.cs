using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

using petStoreMonitoringApp.Models.ViewModels;
using petStoreMonitoringApp.Models;

namespace petStoreMonitoringApp.Controllers
{
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
            var businessMetricsVM = new BusinessMetricsVM();

            HttpResponseMessage response = await client.GetAsync("/api/OnHandMerch");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            businessMetricsVM.OnHandMerchList = JsonSerializer.Deserialize<List<OnHandMerch>>(responseBody, options);

            response = await client.GetAsync("/api/AnimalPurchaseCategories");
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            businessMetricsVM.AnimalPurchaseCategoryList
                = JsonSerializer.Deserialize<List<AnimalPurchaseCategory>>(responseBody, options);

            response = await client.GetAsync("/api/OrderStates");
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            businessMetricsVM.OrderStateList = JsonSerializer.Deserialize<List<OrderState>>(responseBody, options);

            return View(businessMetricsVM);
        }

        //[HttpGet("/Views/Home/ProjectInfo/Performance")]
        public IActionResult Performance()
        {
            return View();
        }
    }
}
