using Domain.Entities;

namespace Domain.Repositories
{
    public interface ISubcategoryRepository : ICRUDRepository<Subcategory>
    {
        public Task<List<Subcategory>> GetAllById(IEnumerable<long> ids);
    }
}
