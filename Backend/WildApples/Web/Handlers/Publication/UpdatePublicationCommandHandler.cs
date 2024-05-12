using Domain.Models.UpdateDTOs;
using Domain.Services;
using Domain.Utils;
using MediatR;
using Web.Models.Commands.Publications;

namespace Web.Handlers.Publication
{
    public class UpdatePublicationCommandHandler(PublicationService publicationService, ContextService contextService,
        SubcategoryService subcategoryService)
        : IRequestHandler<UpdatePublicationCommand>
    {
        public async Task Handle(UpdatePublicationCommand request, CancellationToken cancellationToken)
        {
            var username = contextService.GetUsername();
            var userRole = contextService.GetUserRole();
            var publication = await publicationService.Get(request.Id);

            if (!publication.Owner.Username.Equals(username) && !userRole.Equals(RolesScheme.ADMIN))
            {
                throw new Exception("Frobidden");
            }

            var subcategories = await subcategoryService.GetAllById(request.SubcategoriesId);

            var updateDto = new PublicationUpdateDTO()
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Subcategories = subcategories,
            };
            await publicationService.Update(updateDto);
        }
    }
}
