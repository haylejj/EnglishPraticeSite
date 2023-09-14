using Core.Entity;
using Core.Service;
using Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class RegisterService:IRegisterService
    {

        private readonly UserManager<AppUser> _userManager;
        public RegisterService(UserManager<AppUser> userManager)
        {
            _userManager=userManager;
        }

        public async Task<(bool, IEnumerable<IdentityError>?)> RegisterAsync(RegisterViewModel request)
        {
            var result=await _userManager.CreateAsync(new AppUser() { UserName=request.UserName, Email=request.Email,PhoneNumber=request.Phone},request.Password);
            if (!result.Succeeded)
            {
                return (false, result.Errors);
            }
            else
            {
                return (true, null);
            }
        }
    }
}
