using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebappIdentity_del2.Helpers.Services;
using WebappIdentity_del2.Models.Dtos;
using WebappIdentity_del2.ViewModels;

namespace WebappIdentity_del2.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ProductsViewModel
            {
                Products = await _productService.GetAllAsync()
        };
            return View(viewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductRegistationViewModel viewModel)
        {

            if(ModelState.IsValid)
            {
                var product = await _productService.CreateAsync(viewModel);
                if(product != null) 
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
                    
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "Something went wrong");
            
            return View(viewModel);
        }


    }
}
