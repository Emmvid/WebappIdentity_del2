using WebappIdentity_del2.Models.Dtos;

namespace WebappIdentity_del2.ViewModels
{
    public class HomeViewModel
    {

        public List<ProductSectionViewModel> ProductSections { get; set; }
        public Product? ShowcaseProduct { get; set; }


    }
}
