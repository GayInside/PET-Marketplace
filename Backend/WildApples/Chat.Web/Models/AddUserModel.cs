namespace Chat.Web.Models
{
    public class AddUserModel
    {
        public string Username { get; set; } = null!;

        public required long MainId { get; set; }
    }
}
