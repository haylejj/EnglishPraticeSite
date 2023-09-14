using Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var errors = new List<IdentityError>();
            if (password!.ToLower().Contains(user.UserName!.ToLower())) // buradaki ünlem nullable değer olabilir diye gözteriyo aynı ? işareti gibi proportlerde.
            {
                errors.Add(new IdentityError()
                {
                    Code="PasswordContainUserName",
                    Description="Şifre alanı kullanıcı adı içeremez"
                });
            }
            if (password.ToLower().StartsWith("1234"))
            {
                errors.Add(new IdentityError()
                {
                    Code="PasswordNoContain1234",
                    Description="Şifre alanı ardışık sayı içeremez"
                });
            }
            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            return Task.FromResult(IdentityResult.Success);


        }
    }
}
