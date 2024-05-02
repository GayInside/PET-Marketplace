namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string Firstname { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public virtual IEnumerable<Publication>? Publications { get; set; }

        public virtual IEnumerable<Publication>? Favorites { get; set; }
    }
}
