using System.ComponentModel.DataAnnotations;

namespace petStoreMonitoringApp.Models.ViewModels
{
    public class MaintainEmailVM
    {
        public string UserId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
