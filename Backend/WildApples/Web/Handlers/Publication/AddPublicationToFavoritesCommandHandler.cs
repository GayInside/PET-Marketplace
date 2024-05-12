using Domain.Services;
using MediatR;
using Web.Models.Commands.Publications;

namespace Web.Handlers.Publication
{
    public class AddPublicationToFavoritesCommandHandler(ContextService contextService, UserService userService,
        PublicationService publicationService)
        : IRequestHandler<AddPublicationToFavoritesCommand>
    {
        public async Task Handle(AddPublicationToFavoritesCommand request, CancellationToken cancellationToken)
        {
            var username = contextService.GetUsername();
            var user = await userService.GetByUsername(username);

            await publicationService.AddToFavorites(user, request.Id);
        }
    }
}
