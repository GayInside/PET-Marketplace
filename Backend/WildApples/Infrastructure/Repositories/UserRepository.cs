using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbSet<User> _users = null!;

    public UserRepository(ApplicationContext context)
    {
        _users = context.Users;
    }

    public async Task<User?> GetByUsername(string name)
    {
        var user = await _users.Include(x => x.UserRole)
            .FirstOrDefaultAsync(x => x.Username == name);

        return user;
    }
}
