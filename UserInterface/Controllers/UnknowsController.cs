using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    public class UnknowsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
