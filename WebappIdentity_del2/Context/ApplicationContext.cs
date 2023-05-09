using Microsoft.EntityFrameworkCore;
using WebappIdentity_del2.Models.Entities;

namespace WebappIdentity_del2.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
 

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    public DbSet<ContactFormEntity> ContactForms { get; set; }


}
