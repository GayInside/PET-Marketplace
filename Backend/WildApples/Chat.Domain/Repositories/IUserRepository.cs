using Chat.Domain.Entities;

namespace Chat.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> GetByUsername(string username);

        public Task<long> Add(User user);

        public Task<User?> Get(long id);

        public Task<User?> GetByMainId(long id);
    }
}
