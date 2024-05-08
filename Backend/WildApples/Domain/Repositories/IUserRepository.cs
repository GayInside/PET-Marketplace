using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository : ICRUDRepository<User>
    {
        Task<User?> GetByUsername(string name);
    }
}
