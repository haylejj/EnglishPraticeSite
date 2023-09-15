﻿using Core.Entity;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace UserInterface.TagHelpers
{
    public class UserRoleNameTagHelper:TagHelper
    {
        public string UserId { get; set; } = null!;
        private readonly UserManager<AppUser> _userManager;

        public UserRoleNameTagHelper(UserManager<AppUser> userManager)
        {
            _userManager=userManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByIdAsync(UserId);

            var userRoles = await _userManager.GetRolesAsync(user!);

            var stringBuilder = new StringBuilder();

            userRoles.ToList().ForEach(x =>
            {
                stringBuilder.Append(@$"
                <span class='badge bg-secondary mx-1'>{x.ToLower()}</span>");
            });
            output.Content.SetHtmlContent(stringBuilder.ToString());
        }
    }
}