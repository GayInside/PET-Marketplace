namespace Domain.Entities
{
    public class Publication : BaseEntity
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public virtual User Owner { get; set; } = null!;

        public virtual List<Subcategory> Subcategories { get; set; } = null!;

        public virtual List<User>? UsersWhoLiked { get; set; }
    }
}
