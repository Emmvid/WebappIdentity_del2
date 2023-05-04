using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebappIdentity_del2.Context;
using WebappIdentity_del2.Models.Entities;
using WebappIdentity_del2.ViewModels;

namespace WebappIdentity_del2.Services
{
    public class AuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityContext _identityContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly SeedService _seedService;
        public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager, SeedService seedService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _identityContext = identityContext;
            _signInManager = signInManager;
            _seedService = seedService;
            _roleManager = roleManager;
        }

        public async Task<bool> SignUpAsync(UserSignupViewModel model)
        {
            try
            {
                await _seedService.SeedRoles();
                 //Om det inte finns några användare eller roller, lägg till första användaren i adminrollen
                var roleName = "user";
                if (!await _userManager.Users.AnyAsync())
                {
                    roleName = "admin";
                }
          
                //skapar användare
                IdentityUser identityUser = model;
                await _userManager.CreateAsync(identityUser, model.Password);
                //Om det finns använder, ger de rollen user
                await _userManager.AddToRoleAsync(identityUser, roleName);

                //skapar profilen
                UserProfileEntity userProfileEntity = model;
                userProfileEntity.UserId = identityUser.Id;

                _identityContext.UserProfiles.Add(userProfileEntity);
                //sparar ändringarna 
                await _identityContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> SignInAsync(UserSignInViewModel model)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                return result.Succeeded;
            }
            catch { return false; }
        }

        public async Task<bool> SignOutAsync(ClaimsPrincipal user)
        {
            await _signInManager.SignOutAsync();

            return _signInManager.IsSignedIn(user);


        }
    }
}
