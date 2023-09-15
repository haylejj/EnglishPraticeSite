using Core.Entity;
using Core.ViewModels;

namespace Core.Service
{
    public interface ILoginService
    {
        Task<AppUser> FindByEmailAsync(string email);
        Task<bool> LoginAsync(LoginViewModel request, AppUser user);
        Task<string> GeneratePasswordResetTokenAsync(string userıd);
    }
}
