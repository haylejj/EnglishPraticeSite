using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Service
{
    public interface IAdminService
    {

        Task<List<UserViewModel>> GetUsersAsync();
    }
}
