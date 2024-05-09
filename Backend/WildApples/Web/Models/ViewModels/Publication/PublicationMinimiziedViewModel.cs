namespace Web.Models.ViewModels.Publication
{
    public record PublicationMinimiziedViewModel
    {
        public long Id { get; init; }
        public string Title { get; init; } = null!;
        public string? ImageUrl { get; init; }
    }
}
