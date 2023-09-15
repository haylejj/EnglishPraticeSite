using Core.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Core.Service
{
    public interface IRegisterService
    {
        Task<(bool, IEnumerable<IdentityError>?)> RegisterAsync(RegisterViewModel request);
    }
}
