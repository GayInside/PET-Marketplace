using Chat.Domain.Entities;
using Chat.Domain.Repositories;
using Chat.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _users = context.Users;
            _context = context;
        }

        public async Task<long> Add(User user)
        {
            await _users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<User?> Get(long id)
        {
            return await _users
                .Include(x => x.Chats)
                .Include(x => x.Messages)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _users
                .Include(x => x.Chats)
                .Include(x => x.Messages)
                .SingleOrDefaultAsync(x => x.Username == username);
        }
    }
}
