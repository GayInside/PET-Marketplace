using MediatR;

namespace Web.Models.Commands.Publications
{
    public record DeletePublicationCommand : IRequest
    {
        public required long Id { get; init; }
    }
}
