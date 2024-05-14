using Domain.Entities;

namespace Domain.Models.UpdateDTOs
{
    public record PublicationUpdateDTO
    {
        public required long Id { get; init; }
        public string Title { get; init; } = null!;
        public string? Description { get; init; }
        public List<Subcategory> Subcategories { get; init; } = null!;
    }
}
