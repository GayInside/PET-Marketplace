namespace Domain.Entities
{
    public class Publication : BaseEntity
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public virtual User Owner { get; set; } = null!;

        public IEnumerable<string>? ImageUrls { get; set; }

        public virtual IEnumerable<Subcategory>? Subcategories { get; set; }

        public virtual IEnumerable<User>? UsersWhoLiked { get; set; }
    }
}
