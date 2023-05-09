using WebappIdentity_del2.Context;
using WebappIdentity_del2.Models.Entities;

namespace WebappIdentity_del2.Helpers.Repositories
{
    public class ProductRepository : Repo<ProductEntity>
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
