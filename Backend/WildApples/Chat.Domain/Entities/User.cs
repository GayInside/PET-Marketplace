namespace Chat.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = null!;

        public required long MainId { get; set; }

        public virtual List<Chat> Chats { get; set; } = null!;

        public virtual List<Message>? Messages { get; set; }
    }
}
