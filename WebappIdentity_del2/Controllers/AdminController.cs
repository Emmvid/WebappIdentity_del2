using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappIdentity_del2.ViewModels;

namespace WebappIdentity_del2.Controllers;

//gör så att bara admin kan komma in
[Authorize(Roles =" admin ")]
public class AdminController : Controller
{
    
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;


    public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {

        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<IActionResult> Index()
    {
        var admins = await _userManager.GetUsersInRoleAsync("admin");
        var users = await _userManager.GetUsersInRoleAsync("user");
        var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync(); // Get all available roles

        var model = new AdminViewModel
        {
            Admins = admins,
            Users = users,
            Roles = roles // Assign the list of roles to the view model
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRoles(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            // Handle error: user not found
        }

        // Remove all existing roles
        var userRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, userRoles);

        // Add the selected role
        await _userManager.AddToRoleAsync(user, roleName);

        // Redirect to the UpdateRoles view with a success flag
        return View();
    }



    /* public async Task<IActionResult> Index()
     {

         var admins = (await _userManager
                  .GetUsersInRoleAsync("admin"));


         var users = (await _userManager.GetUsersInRoleAsync("user"));
         var model = new AdminViewModel
         {
             Admins = admins,
             Users = users,
         };


         return View(model);

     }*/
}
