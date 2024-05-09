using Domain.Entities;

namespace Domain.Models.PaginationParams
{
    public record PublicationPaginationParams : BasePaginationParams
    {
        public Subcategory? Subcategory { get; init; }
    }
}
