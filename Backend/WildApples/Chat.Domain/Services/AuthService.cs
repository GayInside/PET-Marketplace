namespace Chat.Domain.Services
{
    public class AuthService
    {
        public const string AUTH_HEADER_NAME = "ChatAuth";

        public bool ValidateToken(string? authToken)
        {
            return authToken is not null;
        }
    }
}
