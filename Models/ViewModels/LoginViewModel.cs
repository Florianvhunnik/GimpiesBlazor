using System.ComponentModel.DataAnnotations;

namespace GimpiesBlazor.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul uw gebruikersnaam/email in")]
        public string UsernameOrEmail { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul uw wachtwoord in")]
        public string Password { get; set; } = string.Empty;
    }
}
