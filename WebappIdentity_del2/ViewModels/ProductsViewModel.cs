using WebappIdentity_del2.Models.Dtos;

namespace WebappIdentity_del2.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
