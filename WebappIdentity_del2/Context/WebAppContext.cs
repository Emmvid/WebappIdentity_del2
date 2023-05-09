using Microsoft.EntityFrameworkCore;
using WebappIdentity_del2.Models.Entities;

namespace WebappIdentity_del2.Context
{
    public class WebAppContext : DbContext
    {
        public WebAppContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ContactFormEntity> ContactForms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
           .HasMany(e => e.Categories)
           .WithMany(e => e.Products);
       
        }
    }
}
