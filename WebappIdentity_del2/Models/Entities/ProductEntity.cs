using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using WebappIdentity_del2.Models.Dtos;

namespace WebappIdentity_del2.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string ProductName { get; set; } = null!;

        public string? Tagline { get; set; }
        public string? Description { get; set; }

        public decimal Price { get; set; }

        //Skapar en koppling till kategorierna

        public ICollection<ProductCategoryEntity> Categories { get; set; } = new HashSet<ProductCategoryEntity>();


        public static implicit operator Product?(ProductEntity entity)
        {


            return entity is not null ? new Product
            {
                ArticleNumber = entity.ArticleNumber,
                ImageUrl = entity.ImageUrl,
                ProductName = entity.ProductName,
                Tagline = entity.Tagline,
                Description = entity.Description,
                Price = entity.Price,
                Categories = entity.Categories,
            } : null;
        }
    }
}
