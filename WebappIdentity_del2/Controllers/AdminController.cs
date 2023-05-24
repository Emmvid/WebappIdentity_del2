using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappIdentity_del2.Helpers.Services;
using WebappIdentity_del2.ViewModels;

namespace WebappIdentity_del2.Controllers;

//gör så att bara admin kan komma in
[Authorize(Roles = " admin ")]
public class AdminController : Controller
{
    #region Constructor and privates
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ProductService _productService;
    private readonly AuthService _auth;

    public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ProductService productService, AuthService authService)
    {

        _userManager = userManager;
        _roleManager = roleManager;
        _productService = productService;
        _auth = authService;
    }
    #endregion
    public async Task<IActionResult> Index()
    {
        var admins = await _userManager.GetUsersInRoleAsync("admin");
        var users = await _userManager.GetUsersInRoleAsync("user");
        var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

        var model = new AdminViewModel
        {
            Admins = admins,
            Users = users,
            Roles = roles
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRoles(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var userRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, userRoles);
        await _userManager.AddToRoleAsync(user, roleName);

        return View();
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductRegistationViewModel viewModel)
    {

        if (ModelState.IsValid)
        {
            var product = await _productService.CreateAsync(viewModel);
            if (product != null)
            {
                if (viewModel.SelectedCategories != null)
                {
                    foreach (var categoryId in viewModel.SelectedCategories)
                    {
                        await _productService.AddCategoryAsync(product, categoryId);
                    }
                }
                if (viewModel.Image != null)
                    await _productService.UploadImageAsync(product, viewModel.Image);

                return RedirectToAction("ProductList");
            }
        }
        ModelState.AddModelError("", "Something went wrong");

        return View(viewModel);
    }


    public async Task<IActionResult> ProductList()
    {
        var viewModel = new ProductSectionViewModel
        {
            Products = await _productService.GetAllAsync()
        };
        return View(viewModel);
    }

    public IActionResult RegisterUser()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> RegisterUser(UserSignupViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _auth.SignUpAsync(model))
                return RedirectToAction("SignIn");

            ModelState.AddModelError("", "User with the same email already exists.");

        }
        return View(model);
    }

}
