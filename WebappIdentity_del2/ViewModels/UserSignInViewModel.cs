using System.ComponentModel.DataAnnotations;
namespace WebappIdentity_del2.ViewModels;

public class UserSignInViewModel
{
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Incorrect email")]
    [Display(Name = "Email *")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Incorrect email")]
    public string Email { get; set; } = null!;
    [DataType(DataType.Password)]

    [Required(ErrorMessage = "Incorrect password")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Incorrect password")]
    [Display(Name = "Password *")]
  
    public string Password { get; set; } = null!;
    public bool RememberMe { get; set; }
}
