using Microsoft.AspNetCore.Mvc;
using WebappIdentity_del2.Helpers.Services;
using WebappIdentity_del2.ViewModels;

namespace WebappIdentity_del2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = new List<string> { "new", "featured", "popular" };
            var productSections = new List<ProductSectionViewModel>();

            foreach (var category in categories)
            {
                var products = await _productService.GetAllAsync(category);

                var categoryViewModel = new ProductSectionViewModel
                {
                    Title = category,
                    Products = products
                };

                productSections.Add(categoryViewModel);
            }
            var showcaseProduct = await _productService.GetAsync("1");

            var viewModel = new HomeViewModel
            {
                ProductSections = productSections,
                ShowcaseProduct = showcaseProduct
            };
            return View(viewModel);
        }

    }
}
