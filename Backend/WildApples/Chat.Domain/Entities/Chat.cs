namespace Chat.Domain.Entities
{
    public class Chat : BaseEntity
    {
        public virtual List<User> UsersInChat { get; set; } = null!;

        public virtual List<Message>? MessagesInChat { get; set; }
    }
}
