using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    public class FavoriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
