using Domain.Entities;
using Domain.Models.PaginationParams;

namespace Domain.Repositories
{
    public interface IPublicationRepository : ICRUDRepository<Publication>, IFilteredRepository<Publication, PublicationPaginationParams>
    {
    }
}
