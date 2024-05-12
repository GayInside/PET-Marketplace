using MediatR;

namespace Web.Models.Commands.Publications
{
    public record CreatePublicationCommand 
        : IRequest<long?>
    {
        public string Title { get; init; } = null!;

        public string? Description { get; init; }

        public IEnumerable<long> SubcategoriesId { get; init; } = null!;

        public IEnumerable<IFormFile>? Photos { get; init; }
    }
}
