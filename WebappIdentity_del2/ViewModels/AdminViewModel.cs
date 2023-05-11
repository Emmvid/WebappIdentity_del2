using Microsoft.AspNetCore.Identity;


namespace WebappIdentity_del2.ViewModels;

public class AdminViewModel
{
    public IList<IdentityUser> Admins { get; set; }

    public IList<IdentityUser> Users { get; set;}
}
