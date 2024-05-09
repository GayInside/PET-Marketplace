using Domain.Entities;

namespace Domain.Models.UpdateDTOs
{
    public record PublicationUpdateDTO
    {
        public required long Id { get; init; }
        public bool IsDisabled { get; init; }
        public string Title { get; init; } = null!;
        public string? Description { get; init; }
        public virtual User Owner { get; init; } = null!;
        public IEnumerable<string>? ImageUrls { get; init; }
        public IEnumerable<Subcategory>? Subcategories { get; init; }
        public IEnumerable<User>? UsersWhoLiked { get; init; }
    }
}
