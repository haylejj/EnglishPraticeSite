﻿using Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IRoleService
    {
        Task<List<RoleViewModel>> GetRoleListAsync();
        Task<(bool, IEnumerable<IdentityError>?)> CreateRoleAsync(RoleCreateViewModel request);
        Task<(bool, RoleUpdateViewModel?)> FindByIdReturnRoleUpdateViewModelAsync(string id);
        Task<(bool, IEnumerable<IdentityError>?)> UpdateRoleAsync(RoleUpdateViewModel request);
        Task<(bool, IEnumerable<IdentityError>?)> DeleteRoleAsync(string id);
        Task<List<AssignToRoleViewModel>> GetRoleByIdReturnAssignToRoleAsync(string id);
        Task AssignRoleAsync(string id, List<AssignToRoleViewModel> request);
    }
}
