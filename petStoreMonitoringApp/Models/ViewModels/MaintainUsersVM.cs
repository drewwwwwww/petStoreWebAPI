using Microsoft.AspNetCore.Identity;

namespace petStoreMonitoringApp.Models.ViewModels
{
    public class MaintainUsersVM
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
        
    }
}
