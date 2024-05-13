namespace Chat.Web.Models
{
    public record MessageViewModel
    {
        public string Username { get; init; } = null!;

        public string Content { get; init; } = null!;

        public long ChatId { get; init; }
    }
}
