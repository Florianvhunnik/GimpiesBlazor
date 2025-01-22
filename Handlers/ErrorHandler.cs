using Microsoft.AspNetCore.Components;

namespace GimpiesBlazor.Handlers
{
    public static class ErrorHandler
    {
        private static readonly Dictionary<int, string> HttpErrorMessages = new()
        {
            { 400, "Er is een fout opgetreden bij het verwerken van je verzoek!" },
            { 401, "Je bent niet geautoriseerd om deze pagina te bekijken!" },
            { 403, "Je hebt geen toegang tot deze pagina!" },
            { 404, "De pagina die je zoekt bestaat niet of is verplaatst!" },
            { 405, "De gebruikte HTTP-methode is niet toegestaan!" },
            { 408, "Het verzoek duurde te lang om te verwerken!" },
            { 429, "Te veel verzoeken! Probeer het later opnieuw." },
            { 500, "Er is een serverfout opgetreden!" },
            { 502, "Er trad een fout op in de gateway!" },
            { 503, "De service is tijdelijk niet beschikbaar. Probeer het later opnieuw." },
            { 504, "De server heeft te lang gewacht op een antwoord!" },
        };

        private static readonly Dictionary<int, string> ProgramErrorMessages = new()
        {
            { 0, "Er is een fout opgetreden bij het verwerken van je verzoek!" },
            { 1, "Er is een onbekende fout opgetreden!" }
        };

        public static string GetErrorMessage(int httpErrorCode)
        {
            return HttpErrorMessages.GetValueOrDefault(httpErrorCode, "Onbekende HTTP-fout");
        }

        public static string GetErrorMessage(ProgramError programError)
        {
            return ProgramErrorMessages.GetValueOrDefault((int)programError, "Onbekende programmafout");
        }

        public static int GetErrorCode(ProgramError customError)
        {
            return (int)customError;
        }

        public static ProgramError GetProgramError(int errorCode)
        {
            return (ProgramError)errorCode;
        }

        public static MarkupString AddErrorCode(string? errorMessage, ProgramError? error)
        {
            error ??= ProgramError.UnknownError;
            errorMessage ??= GetErrorMessage((ProgramError)error);

            return new MarkupString(
                $"{errorMessage} (<a href='/error/{(int)error}' class='text-danger'>Foutcode {(int)error}</a>)");
        }
    }

    public enum ProgramError
    {
        DatabaseError,
        UnknownError
    }
}
