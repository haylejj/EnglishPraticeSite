using Core.Service;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using UserInterface.Extensions;

namespace UserInterface.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService=loginService;
        }

        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel request,string ?returnUrl=null)
        {
            if (!ModelState.IsValid) // bir hata var ise validate de
            {
                return View();
            }
            returnUrl=returnUrl ?? Url.Action("Index", "Word");

            var user=await _loginService.FindByEmailAsync(request.Email);
            if (user == null)
            {
                ModelState.AddModelErrorList(new List<string>() { "Email veya şifre yanlış" });
            }

            var result =await  _loginService.LoginAsync(request,user!);

            if (result)
            {
                return Redirect(returnUrl!);
            }

            ModelState.AddModelErrorList(new List<string> { "Email veya şifre yanlış" });
            return View();
        }

    }
}
