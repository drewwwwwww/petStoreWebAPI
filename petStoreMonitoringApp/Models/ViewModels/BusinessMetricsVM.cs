namespace petStoreMonitoringApp.Models.ViewModels
{
    public class BusinessMetricsVM
    {
        public List<OnHandMerch> OnHandMerchList { get; set; }
        public List<AnimalPurchaseCategory> AnimalPurchaseCategoryList { get; set; }
        public List<OrderState> OrderStateList { get; set; }
    }
}
