namespace Domain.Models
{
    public record UserCredentials
    {
        public string Username { get; init; } = null!;

        public string Password { get; init; } = null!;
    }
}
