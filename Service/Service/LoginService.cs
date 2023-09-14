using Core.Entity;
using Core.Service;
using Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class LoginService:ILoginService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
       
        public LoginService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
        }
        public async Task<AppUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task<bool> LoginAsync(LoginViewModel request,AppUser user)
        {
            var result =await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe,true);
            
           if(result.Succeeded)
            {
                return (true);
            }

            return (false) ;
        }
    }
}
