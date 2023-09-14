using Core.Entity;
using Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ILoginService
    {
         Task<AppUser> FindByEmailAsync(string email);
        Task<bool> LoginAsync(LoginViewModel request, AppUser user);
    }
}
