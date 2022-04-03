namespace petStoreMonitoringApp.Models.ViewModels
{
    public class BusinessMetricsVM
    {
        //raw data
        public List<OnHandMerch> OnHandMerchList { get; set; }
        public List<AnimalPurchaseCategory> AnimalPurchaseCategoryList { get; set; }
        public List<OrderState> OrderStateList { get; set; }

        //aggregated data
        public List<OnHandMerch> MostRecentOnHandMerch { get; set; }
    }
}
