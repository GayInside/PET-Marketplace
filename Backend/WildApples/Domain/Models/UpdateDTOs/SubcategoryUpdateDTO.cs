using Domain.Entities;

namespace Domain.Models.UpdateDTOs
{
    public record SubcategoryUpdateDTO
    {
        public required long Id { get; init; }
        public bool IsDisabled { get; init; }
        public string Title { get; init; } = null!;
        public Category Category { get; init; } = null!;
        public List<Publication>? Publications { get; init; }
    }
}
