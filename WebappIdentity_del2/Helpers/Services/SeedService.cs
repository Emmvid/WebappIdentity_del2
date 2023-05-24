using Microsoft.AspNetCore.Identity;

namespace WebappIdentity_del2.Helpers.Services;

public class SeedService
{
    #region Constructor and private
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }
    #endregion
    public async Task SeedRoles()
    {
        if (!await _roleManager.RoleExistsAsync("admin"))
        {
            await _roleManager.CreateAsync(new IdentityRole("admin"));
        }
        if (!await _roleManager.RoleExistsAsync("user"))
        {
            await _roleManager.CreateAsync(new IdentityRole("user"));
        }
    }
}


