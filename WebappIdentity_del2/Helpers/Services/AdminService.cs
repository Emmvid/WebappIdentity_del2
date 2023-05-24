using Microsoft.AspNetCore.Identity;

namespace WebappIdentity_del2.Services;

public class AdminService
{
    #region Private and constructor
    private readonly UserManager<IdentityUser> _userManager;

    public AdminService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    #endregion

    public async Task<bool> UpdateRoles(string userId, string roleName)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);

            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);


            await _userManager.AddToRoleAsync(user, roleName);
            return true;
        }
        catch { return false; }

    }

}
