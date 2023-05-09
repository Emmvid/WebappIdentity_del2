using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebappIdentity_del2.Models.Entities;

namespace WebappIdentity_del2.ViewModels;

public class UserSignupViewModel
{
    [Required(ErrorMessage = "You have to submit a first name")]
    [Display(Name = "First Name *")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$", ErrorMessage = "You must submit a valid firstname")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "You have to submit a last name")]
    [Display(Name = "Last Name *")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$", ErrorMessage = "You must submit a valid lastname")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "You have to submit an email")]
    [Display(Name = "Email *")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You have to submit a valid email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You have to submit a password")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "You have to submit a valid password")]
    [Display(Name = "Password *")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "You have to confirm your password")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "The passwords doesn't match")]
    [Display(Name = "Password *")]

    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string ConfirmPassword{ get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? StreetName { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    public static implicit operator IdentityUser(UserSignupViewModel model)
    {
        return new IdentityUser
        {
            UserName = model.Email,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
        };
    }
    public static implicit operator UserProfileEntity(UserSignupViewModel model)
    {
        return new UserProfileEntity
        {
            
            FirstName = model.FirstName,
            LastName = model.LastName,
            StreetName = model.StreetName,
            PostalCode = model.PostalCode,
            City = model.City,
        };
    }
}
