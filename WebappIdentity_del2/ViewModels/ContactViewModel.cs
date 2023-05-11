
using System.ComponentModel.DataAnnotations;
using WebappIdentity_del2.Models.Dtos;
using WebappIdentity_del2.Models.Entities;

namespace WebappIdentity_del2.ViewModels;

public class ContactViewModel
{

    [Required(ErrorMessage = "You have to submit a first name")]
    [Display(Name = "First Name *")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$", ErrorMessage = "You must submit a valid firstname")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "You have to submit an email")]
    [Display(Name = "Email *")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You have to submit a valid email")]
    public string Email { get; set; } = null!;
    
    public string? Phone { get; set; }
    public string? Subject { get; set; }

    [Required(ErrorMessage = "You have to submit a Message")]
    [Display(Name = "Message *")]
    public string Message { get; set; } = null!;

    public static implicit operator ContactFormEntity(ContactViewModel model)
    {
        return new ContactFormEntity
        {
            Name = model.Name,
            Email = model.Email,
            Phone = model.Phone,
            Subject = model.Subject,
            Message = model.Message,
        };

    }


}
