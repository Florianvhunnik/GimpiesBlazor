using System.ComponentModel.DataAnnotations;

namespace GimpiesBlazor.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul uw gebruikersnaam in")]
        public string Username { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul uw email in")]
        public string Email { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul uw wachtwoord in")]
        public string Password { get; set; } = string.Empty;
    }
}
