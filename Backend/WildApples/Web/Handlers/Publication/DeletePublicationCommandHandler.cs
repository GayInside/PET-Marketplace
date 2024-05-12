using Domain.Services;
using Domain.Utils;
using MediatR;
using Web.Models.Commands.Publications;

namespace Web.Handlers.Publication
{
    public class DeletePublicationCommandHandler(PublicationService publicationService, ContextService contextService)
        : IRequestHandler<DeletePublicationCommand>
    {
        public async Task Handle(DeletePublicationCommand request, CancellationToken cancellationToken)
        {
            var username = contextService.GetUsername();
            var userRole = contextService.GetUserRole();
            var publication = await publicationService.Get(request.Id);

            if(!publication.Owner.Username.Equals(username) && !userRole.Equals(RolesScheme.ADMIN))
            {
                throw new Exception("Frobidden");
            }

            await publicationService.Delete(request.Id);
        }
    }
}
