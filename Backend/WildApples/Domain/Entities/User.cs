namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string Firstname { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public virtual List<Publication>? Publications { get; set; }

        public virtual List<Publication>? Favorites { get; set; }

        public virtual Role UserRole { get; set; } = null!;
    }
}
