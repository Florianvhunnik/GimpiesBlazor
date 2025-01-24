using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GimpiesBlazor.Managers
{
    public class ValidationManager
    {
        public static IEnumerable<string> ValidPassword(string password, bool login)
        {
            if (string.IsNullOrWhiteSpace(password))
                yield return "Vul uw wachtwoord in";
            if (login)
                yield break;
            if (password.Length < 8)
                yield return "Wachtwoord moet minimaal 8 tekens bevatten";
            if (!Regex.IsMatch(password, @"[a-z]"))
                yield return "Wachtwoord moet minimaal 1 kleine letter bevatten";
            if (!Regex.IsMatch(password, @"[A-Z]"))
                yield return "Wachtwoord moet minimaal 1 hoofdletter bevatten";
            if (!Regex.IsMatch(password, @"[0-9]"))
                yield return "Wachtwoord moet minimaal 1 cijfer bevatten";
        }

        public static IEnumerable<string> ValidUsername(string username, bool login)
        {
            if (string.IsNullOrWhiteSpace(username))
                yield return "Vul uw gebruikersnaam in";
            if (login)
                yield break;
            if (username.Length < 5)
                yield return "Gebruikersnaam moet minimaal 5 tekens bevatten";
            if (Regex.IsMatch(username, @"[0-9]"))
                yield return "Gebruikersnaam mag geen cijfers bevatten";
            if (Regex.IsMatch(username, @"[^\w\.@-]"))
                yield return "Gebruikersnaam mag geen speciale tekens bevatten";
        }

        public static IEnumerable<string> ValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                yield return "Vul uw E-Mail in";
            if (!new EmailAddressAttribute().IsValid(email))
                yield return "Vul een geldig E-Mail adres in";
        }

        public static IEnumerable<string> MatchPassword(string password, string passwordRepeat)
        {
            if (string.IsNullOrWhiteSpace(passwordRepeat))
                yield return "Bevestig uw wachtwoord";
            if (password != passwordRepeat)
                yield return "Wachtwoorden komen niet overeen";
        }
    }
}
