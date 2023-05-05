using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebappIdentity_del2.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        //Skapar en koppling till kategorierna
        public ICollection<CategoryEntity> Categories { get; set; } = null!;

    }
}
