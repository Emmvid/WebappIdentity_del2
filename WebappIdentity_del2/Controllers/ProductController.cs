using Microsoft.AspNetCore.Mvc;
using WebappIdentity_del2.Helpers.Services;
using WebappIdentity_del2.ViewModels;

namespace WebappIdentity_del2.Controllers
{

    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ProductSectionViewModel
            {
                Products = await _productService.GetAllAsync()
            };
            return View(viewModel);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var product = await _productService.GetAsync(id);

            return View(product);
        }
    }
}
