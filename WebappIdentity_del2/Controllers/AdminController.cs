using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebappIdentity_del2.Controllers;

//gör så att bara admin kan komma in
[Authorize(Roles = "admin")]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
