using System.ComponentModel.DataAnnotations;

namespace WebappIdentity_del2.Models.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProductEntity> Products { get; set; } = null!;

    }
}
