using System.ComponentModel.DataAnnotations;

namespace FunFox.PortalSystem.Domain.ViewModels.Accounts;

public class LoginViewModel
{
    [Required]
    [Display(Name = nameof(Email))]
    [MinLength(3, ErrorMessage = "{0} length at least of {1}.")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [Display(Name = nameof(Password))]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "{0} length at least of {1}.")]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}