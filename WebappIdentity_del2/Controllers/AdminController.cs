﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebappIdentity_del2.ViewModels;

namespace WebappIdentity_del2.Controllers;

//gör så att bara admin kan komma in
[Authorize(Roles =" admin ")]
public class AdminController : Controller
{
    
    private readonly UserManager<IdentityUser> _userManager;


  
    public AdminController( UserManager<IdentityUser> userManager)
    {
      
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
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
       
    }
}
