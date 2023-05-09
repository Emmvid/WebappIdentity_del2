using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebappIdentity_del2.Models.Entities
{
    public class ContactFormEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        [Column(TypeName = "nvarchar(20)")]
        public string? Phone { get; set; }
        public string? Subject { get; set; }
        public string Message { get; set; } = null!;
    }
}
