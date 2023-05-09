using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebappIdentity_del2.Models.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; } = null!;
        public ICollection<ProductCategoryEntity> Products { get; set; } = new HashSet<ProductCategoryEntity>();

    }
}
