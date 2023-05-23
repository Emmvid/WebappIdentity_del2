using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using WebappIdentity_del2.Models.Dtos;

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

        public static implicit operator ContactForm(ContactFormEntity entity)
        {
            return new ContactForm
            {
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Subject = entity.Subject,
                Message = entity.Message,
            };

        }
    }
}
