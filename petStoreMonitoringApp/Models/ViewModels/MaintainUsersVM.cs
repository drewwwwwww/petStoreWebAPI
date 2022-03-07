using Microsoft.AspNetCore.Identity;

namespace petStoreMonitoringApp.Models.ViewModels
{
    public class MaintainUsersVM
    {
        public IList<IdentityUser> AdminUsers { get; set; }
        public IList<IdentityUser> Users { get; set; }
    }
}
