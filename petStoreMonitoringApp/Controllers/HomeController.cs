using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using petStoreMonitoringApp.Models;
using petStoreMonitoringApp.Models.ViewModels;
using System.Diagnostics;

namespace petStoreMonitoringApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public async Task<IActionResult> MaintainUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var maintainUserVM = new List<MaintainUsersVM>();
            foreach (var user in users)
            {
                var tempViewModel = new MaintainUsersVM();
                tempViewModel.UserId = user.Id;
                tempViewModel.UserName = user.UserName;
                tempViewModel.Email = user.Email;
                tempViewModel.Roles = await GetUserRoles(user);
                maintainUserVM.Add(tempViewModel);
            }
            return View(maintainUserVM);
        }

        #region GetUserRoles
        private async Task<List<string>> GetUserRoles(IdentityUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
        #endregion

        #region ManageUserRolesGet
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;
            var model = new List<ManageUserRolesVM>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesVM
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }
        #endregion

        #region ManageUserRolesPost
        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<ManageUserRolesVM> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("Index");
        }
        #endregion

        public IActionResult MaintainMetrics()
        {
            return View();
        }

        public IActionResult MaintainProjects()
        {
            return View();
        }

        public IActionResult User()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}