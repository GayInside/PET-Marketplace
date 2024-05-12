namespace Domain.Models
{
    public record CreateUserModel
    {
        public string Username { get; init; } = null!;

        public string Password { get; init; } = null!;

        public string Firstname { get; init; } = null!;

        public string Surname { get; init; } = null!;
    }
}
