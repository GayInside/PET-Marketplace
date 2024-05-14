using Domain.Services;
using MediatR;
using Web.Models.Commands.Publications;

namespace Web.Handlers.Publication
{
    public class CreatePublicationCommandHandler(ContextService contextService, PublicationService publicationService,
        UserService userService, SubcategoryService subcategoryService)
        : IRequestHandler<CreatePublicationCommand, long?>
    {
        public async Task<long?> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
        {
            var username = contextService.GetUsername();

            var user = await userService.GetByUsername(username);
            var subcategories = await subcategoryService.GetAllById(request.SubcategoriesId);

            var publication = new Domain.Entities.Publication()
            {
                Title = request.Title,
                Owner = user,
                Subcategories = subcategories,
                Description = request.Description,
            };

            var id = await publicationService.Add(publication);
            return id;
        }
    }
}
