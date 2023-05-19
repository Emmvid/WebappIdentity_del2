using System.Runtime.CompilerServices;
using WebappIdentity_del2.Models.Dtos;

namespace WebappIdentity_del2.ViewModels
{
    public class ProductSectionViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public string Title { get; set; } = "";

    }
}
