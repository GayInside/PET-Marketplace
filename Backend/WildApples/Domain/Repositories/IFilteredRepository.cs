using Domain.Entities;
using Domain.Models.PaginationParams;

namespace Domain.Repositories
{
    public interface IFilteredRepository<T1, T2> 
        where T1 : BaseEntity
        where T2 : BasePaginationParams       
    {
        public Task<List<T1>> GetItems(T2 filter);
    }
}
