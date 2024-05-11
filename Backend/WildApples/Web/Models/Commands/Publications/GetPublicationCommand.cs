using MediatR;
using Web.Models.ViewModels.Publication;

namespace Web.Models.Commands.Publications
{
    public record GetPublicationCommand : IRequest<PublicationMaximizedViewModel>
    {
        public required long Id {  get; init; }
    }
}
