using MediatR;

namespace Web.Models.Commands.Publications
{
    public record AddPublicationToFavoritesCommand : IRequest
    {
        public required long Id { get; init; }
    }
}
