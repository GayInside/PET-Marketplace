using Domain.Entities;

namespace Domain.Models.UpdateDTOs
{
    public record PublicationUpdateDTO
    {
        public required long Id { get; init; }
        public bool IsDisabled { get; init; }
        public string Title { get; init; } = null!;
        public string? Description { get; init; }
        public User Owner { get; init; } = null!;
        public List<string>? ImageUrls { get; init; }
        public List<Subcategory> Subcategories { get; init; } = null!;
        public List<User>? UsersWhoLiked { get; init; }
    }
}
