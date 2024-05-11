using Domain.Services;
using Domain.Utils;
using MediatR;
using Web.Models.Commands.Publications;
using Web.Models.ViewModels.Publication;

namespace Web.Handlers.Publication
{
    public class GetPublicationCommandHandler(PublicationService publicationService, ContextService contextService)
        : IRequestHandler<GetPublicationCommand, PublicationMaximizedViewModel>
    {
        public async Task<PublicationMaximizedViewModel> Handle(GetPublicationCommand request, CancellationToken cancellationToken)
        {
            var publication = await publicationService.Get(request.Id);
            var currentUserUsername = contextService.GetUsername();
            var currentUserRole = contextService.GetUserRole();

            var viewModel = new PublicationMaximizedViewModel()
            {
                Id = publication.Id,
                Title = publication.Title,
                Description = publication.Description,
                OwnerId = publication.Owner.Id,
                SubcategoryTitles = publication.Subcategories.Select(x => x.Title),
                Photos = null,//Add minio
                CountOfLikes = publication.UsersWhoLiked?.Count() ?? 0,
                CanDelete = currentUserUsername.Equals(publication.Owner.Username) || currentUserRole.Equals(RolesScheme.ADMIN)
            };
            
            return viewModel;
        }
    }
}
