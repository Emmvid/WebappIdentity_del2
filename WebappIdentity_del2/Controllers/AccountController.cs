using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebappIdentity_del2.Services;
using WebappIdentity_del2.ViewModels;

namespace WebappIdentity_del2.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _auth;

        public AccountController(AuthService auth)
        {
            _auth = auth;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignupViewModel model )
        {
            if(ModelState.IsValid) {
                if(await _auth.SignUpAsync(model))
                return RedirectToAction("SignIn");

                ModelState.AddModelError("", "User with the same email already exists.");

            }
            return View(model);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.SignInAsync(model))
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Incorrect email or password");

            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> SignOut()
        {
           if( await _auth.SignOutAsync(User))
                return LocalRedirect("/");

            return RedirectToAction("Index");
        }
    }
}
