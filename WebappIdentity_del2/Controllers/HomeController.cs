using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappIdentity_del2.Helpers.Services;
using WebappIdentity_del2.Models.Dtos;
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

        /*   public async Task<IActionResult> Index()
           {
               var categories = new List<string> { "new", "featured", "popular" };


               if (categories.Any())
               {
                   foreach (var category in categories)
                   {
                       var products = await _productService.GetAllAsync(category);

                       var categoryViewModel = new ProductSectionViewModel
                       {
                           Title = category,
                           Products = products
                       };
                       return View(categoryViewModel);
                   }
               }
                 return RedirectToAction("index", "product");

           }*/
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

            return View(productSections);
        }

    }
}
