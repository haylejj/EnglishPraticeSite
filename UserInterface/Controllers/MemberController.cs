using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService=memberService;
        }

        public async Task<IActionResult> LogOut()
        {
           await  _memberService.LogOutAsync();
            return RedirectToAction("LogIn","Login");
        }
    }
}
