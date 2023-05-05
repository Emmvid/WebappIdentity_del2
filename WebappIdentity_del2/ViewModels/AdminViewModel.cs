using Microsoft.AspNetCore.Identity;
using WebappIdentity_del2.Services;

namespace WebappIdentity_del2.ViewModels;

public class AdminViewModel
{
    public IdentityUser[] Admins { get; set; }

    public IdentityUser[] Users { get; set;}

   
}
