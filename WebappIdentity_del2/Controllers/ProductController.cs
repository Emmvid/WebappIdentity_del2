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
            return View();
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
                    if(viewModel.Image != null) 
                    await _productService.UploadImageAsync(product, viewModel.Image);
                    
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "Something went wrong");
            
            return View(viewModel);
        }


    }
}
