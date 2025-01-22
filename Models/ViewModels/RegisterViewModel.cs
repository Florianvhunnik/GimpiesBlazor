using System.ComponentModel.DataAnnotations;

namespace GimpiesBlazor.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul uw gebruikersnaam in")]
        public string Username { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul uw E-Mail in")]
        public string Email { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul uw wachtwoord in")]
        public string Password { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Herhaal uw wachtwoord")]
        public string PasswordRepeat { get; set; } = string.Empty;
    }
}
