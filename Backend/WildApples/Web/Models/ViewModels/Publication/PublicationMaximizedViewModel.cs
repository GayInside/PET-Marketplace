using Domain.Entities;

namespace Web.Models.ViewModels.Publication
{
    public record PublicationMaximizedViewModel
    {
        public required long Id { get; init; }

        public IEnumerable<string> SubcategoryTitles { get; init; } = null!;

        public string Title { get; init; } = null!;

        public string? Description { get; init; }

        public bool CanDelete { get; init; } = false;

        public long? OwnerId { get; init; }

        public IEnumerable<IFormFile>? Photos { get; init; }

        public long CountOfLikes { get; init; } = 0;
    }
}
