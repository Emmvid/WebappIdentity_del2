using Microsoft.AspNetCore.Mvc;

namespace WebappIdentity_del2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
