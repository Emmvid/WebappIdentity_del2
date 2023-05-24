using WebappIdentity_del2.Models.Entities;

namespace WebappIdentity_del2.Models.Dtos;

public class Product
{
    public string ArticleNumber { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string ProductName { get; set; } = null!;

    public string? Tagline { get; set; }
    public string? Description { get; set; }

    public decimal Price { get; set; }

    public ICollection<ProductCategoryEntity> Categories { get; set; } = new HashSet<ProductCategoryEntity>();

    public static implicit operator ProductEntity(Product product)
    {
        var entity = new ProductEntity
        {
            ArticleNumber = product.ArticleNumber,
            ImageUrl = product.ImageUrl,
            ProductName = product.ProductName,
            Tagline = product.Tagline,
            Description = product.Description,
            Price = product.Price,
        };

        return entity;
    }
}
