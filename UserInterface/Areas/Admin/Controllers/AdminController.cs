using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace UserInterface.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService=adminService;
        }

        public async Task<IActionResult> UserList()
        {
            var users=await _adminService.GetUsersAsync();
            return View(users);
        }
    }
}
