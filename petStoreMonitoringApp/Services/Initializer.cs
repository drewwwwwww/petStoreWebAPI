using Microsoft.AspNetCore.Identity;

namespace petStoreMonitoringApp.Services
{
    public class Initializer
    {
        private readonly petStoreMonitoringAppContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="roleManager"></param>
        /// <param name="userManager"></param>
        public Initializer(petStoreMonitoringAppContext db,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedRolesAsync()
        {
            _db.Database.EnsureCreated();

            //Adding roles to database
            if(!_db.Roles.Any(role => role.Name == "Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }
            if(!_db.Roles.Any(role => role.Name == "User"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
            }

            //Creates admin if there is not one
            if(!_db.Users.Any(user => user.UserName == "admin@admin.com"))
            {
                var user = new IdentityUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };
                await _userManager.CreateAsync(user, "Admin1!");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
