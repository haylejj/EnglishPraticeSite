using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IEmailService
    {
        Task SendResetPasswordLinkToEmailAsync(string resetEmailLink, string toEmail);
    }
}
