using Microsoft.AspNetCore.Mvc;
using WebappIdentity_del2.Helpers.Services;
using WebappIdentity_del2.ViewModels;

namespace WebappIdentity_del2.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contactForm = await _contactService.CreateAsync(model);
                
               
                    return RedirectToAction("Index");
                
            }
            ModelState.AddModelError("", "Something went wrong");

            return View(model);
            
        }
    }
}
