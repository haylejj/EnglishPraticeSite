using Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IRegisterService
    {
        Task<(bool, IEnumerable<IdentityError>?)> RegisterAsync(RegisterViewModel request);
    }
}
