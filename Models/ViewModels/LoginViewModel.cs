using System.ComponentModel.DataAnnotations;

namespace GimpiesBlazor.Models.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
