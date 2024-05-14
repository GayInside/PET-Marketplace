namespace Infrastructure.APIs.ChatAPI
{
    public record UserDTO
    {
        public long MainId { get; init; }

        public string Username { get; init; } = null!;
    }
}
