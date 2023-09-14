using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }
        
    }
}
