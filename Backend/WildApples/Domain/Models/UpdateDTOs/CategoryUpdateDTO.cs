using Domain.Entities;

namespace Domain.Models.UpdateDTOs
{
    public record CategoryUpdateDto
    {
        public required long Id { get; init; }

        public bool IsDisabled { get; init; }

        public string Title { get; init; } = null!;

        public IEnumerable<Subcategory> Subcategories { get; init; } = null!;
    }
}
