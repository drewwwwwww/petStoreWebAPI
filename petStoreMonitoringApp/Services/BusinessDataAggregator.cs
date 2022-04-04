using petStoreMonitoringApp.Models;
using petStoreMonitoringApp.Models.ViewModels;
using System.Text.Json;

namespace petStoreMonitoringApp.Services
{
    public static class BusinessDataAggregator
    {

        private const string BASE_ADDRESS = "https://se2monitoringwebapi.azurewebsites.net";

        private static readonly HttpClient client = new HttpClient();
        private static JsonSerializerOptions options
            = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        static BusinessDataAggregator()
        {
            client.BaseAddress = new Uri(BASE_ADDRESS);
        }

        public static async Task<BusinessMetricsVM> GetDataFromAPI()
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
        
            return businessMetricsVM;
        }

        public static BusinessMetricsVM AggregateData(BusinessMetricsVM businessMetricsVM)
        {
            businessMetricsVM.MostRecentOnHandMerch = (
                from onHandMerch in businessMetricsVM.OnHandMerchList
                group onHandMerch by onHandMerch.ItemId into onHandMerchByItem
                orderby onHandMerchByItem.Key
                select onHandMerchByItem.MaxBy(x => x.TimeStamp)).ToList();

            businessMetricsVM.TotalAnimalsInCategoryPurchased = businessMetricsVM.AnimalPurchaseCategoryList
                .GroupBy(x => x.Category)
                .OrderBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Count());

            businessMetricsVM.TotalOrdersInState = businessMetricsVM.OrderStateList
                .GroupBy(x => x.State)
                .OrderBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Count());

            return businessMetricsVM;
        }
    }
}
