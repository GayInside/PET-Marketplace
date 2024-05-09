using Domain.Entities;
using Domain.Models;
using Web.Models.ViewModels.Publication;

namespace Web.Models.Commands.Publications
{
    public record GetPublicationsWithPaginationCommand : PaginatedRequest<PaginatedList<PublicationMinimiziedViewModel>>
    {
        public long SubcategoryId { get; init; } = 0;
    }
}
