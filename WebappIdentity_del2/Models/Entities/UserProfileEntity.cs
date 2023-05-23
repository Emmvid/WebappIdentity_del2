using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebappIdentity_del2.Models.Entities
{
    public class UserProfileEntity
    {
        [Key, ForeignKey("User")]
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? StreetName { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public IdentityUser User { get; set; } = null!;
    }
}
