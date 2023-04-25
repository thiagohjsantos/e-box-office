using EBoxOffice.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;

namespace EBoxOffice.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(RoleManager<IdentityRole> roleManager,
               UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("user@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "user@localhost";
                user.Email = "user@localhost";
                user.NormalizedUserName = "USER@LOCALHOST";
                user.NormalizedEmail = "USER@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "#TempPass123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("company@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "company@localhost";
                user.Email = "company@localhost";
                user.NormalizedUserName = "COMPANY@LOCALHOST";
                user.NormalizedEmail = "COMPANY@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "#TempPass123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Company").Wait();
                }
            }

        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Company").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Company";
                role.NormalizedName = "COMPANY";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
