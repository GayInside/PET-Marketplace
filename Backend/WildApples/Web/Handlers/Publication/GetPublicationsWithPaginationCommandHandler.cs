using Domain.Entities;
using Domain.Models;
using Domain.Models.PaginationParams;
using Domain.Services;
using MediatR;
using Web.Models.Commands.Publications;
using Web.Models.Converters;
using Web.Models.ViewModels.Publication;

namespace Web.Handlers.Publication
{
    public class GetPublicationsWithPaginationCommandHandler(PublicationService publicationService, SubcategoryService subcategoryService)
        : IRequestHandler<GetPublicationsWithPaginationCommand, PaginatedList<PublicationMinimiziedViewModel>>
    {
        public async Task<PaginatedList<PublicationMinimiziedViewModel>> Handle(GetPublicationsWithPaginationCommand request, CancellationToken cancellationToken)
        {
            Subcategory? subcategory = null;
            if(request.SubcategoryId != 0)
            {
                subcategory = await subcategoryService.Get(request.SubcategoryId);
            }

            var filter = new PublicationPaginationParams()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Subcategory = subcategory
            };

            var items = (await publicationService.GetItems(filter)).Select(GetPublicationMinimizedViewModel.From);
            var paginatedList = PaginatedList<PublicationMinimiziedViewModel>.Create(items, request.PageNumber, request.PageSize);

            return paginatedList;
        }
    }
}
