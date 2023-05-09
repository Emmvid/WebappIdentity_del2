/*using Microsoft.AspNetCore.Identity;

namespace WebappIdentity_del2.Services;

public class AdminService
{
    private readonly UserManager<IdentityUser> _userManager;

    public AdminService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<IdentityUser>> GetAllAdminsAsync(string roleName)
    {  
        var userInRole = (await _userManager.GetUsersInRoleAsync(roleName)).ToArray(); 

        return userInRole;
    }
 

}*/
