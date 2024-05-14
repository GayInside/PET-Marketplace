namespace Chat.Domain.Entities
{
    public class Message : BaseEntity
    {
        public virtual User User { get; set; } = null!;

        public string Content { get; set; } = null!;

        public virtual Chat Chat { get; set; } = null!;
    }
}
