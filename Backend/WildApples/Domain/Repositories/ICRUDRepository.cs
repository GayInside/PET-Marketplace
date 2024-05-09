using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICRUDRepository<T>
        where T : BaseEntity
    {
        public Task<T?> Get(long id);

        public Task Update(T entity);

        public Task Add(T entity);

        public Task Delete(T entity);
    }
}
