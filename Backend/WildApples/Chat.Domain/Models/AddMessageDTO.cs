namespace Chat.Domain.Models
{
    public record AddMessageDTO
    {
        public string Username { get; init; } = null!;

        public string Content { get; init; } = null!;

        public long ChatId { get; init; }
    }
}
