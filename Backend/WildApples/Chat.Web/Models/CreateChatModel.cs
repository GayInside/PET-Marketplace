namespace Chat.Web.Models
{
    public record CreateChatModel
    {
        public required long FirstUserId { get; init; }

        public required long SecondUserId { get; init; }
    }
}
