using System.ComponentModel.DataAnnotations;

namespace WebappIdentity_del2.ViewModels;

public class UserSignInViewModel
{
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    public bool RememberMe { get; set; }
}
