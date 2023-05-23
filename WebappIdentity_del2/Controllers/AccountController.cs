using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebappIdentity_del2.Helpers.Services;
using WebappIdentity_del2.ViewModels;

namespace WebappIdentity_del2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;
        private readonly AuthService _auth;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserService userService, AuthService auth, UserManager<IdentityUser> userManager)
        {
            _userService = userService;
            _auth = auth;
            _userManager = userManager;
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);


            var firstNameClaim = User.Claims.FirstOrDefault(c => c.Type == "FirstName");
            var lastNameClaim = User.Claims.FirstOrDefault(c => c.Type == "LastName");
            var streetNameClaim = User.Claims.FirstOrDefault(c => c.Type == "StreetName");
            var postalCodeClaim = User.Claims.FirstOrDefault(c => c.Type == "PostalCode");
            var cityClaim = User.Claims.FirstOrDefault(c => c.Type == "City");

            var viewModel = new UserSignupViewModel
            {

                Email = user.Email,
                FirstName = firstNameClaim?.Value,
                LastName = lastNameClaim?.Value,
                StreetName = streetNameClaim?.Value,
                PostalCode = postalCodeClaim?.Value,
                City = cityClaim?.Value
            };

            return View(viewModel);
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.SignUpAsync(model))
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
            if (await _auth.SignOutAsync(User))
                return LocalRedirect("/");

            return RedirectToAction("Index");
        }


    }
}
