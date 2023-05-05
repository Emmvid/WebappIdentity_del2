using Microsoft.EntityFrameworkCore;
using WebappIdentity_del2.Models.Entities;

namespace WebappIdentity_del2.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .HasMany(e => e.Categories)
                .WithMany(e => e.Products);
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

    
    }
}

   
