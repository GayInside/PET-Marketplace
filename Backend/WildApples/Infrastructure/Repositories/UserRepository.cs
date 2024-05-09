using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbSet<User> _users = null!;
    private readonly ApplicationContext _context = null!;

    public UserRepository(ApplicationContext context)
    {
        _users = context.Users;
        _context = context;
    }

    public async Task Add(User entity)
    {
        await _users.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(User entity)
    {
        _users.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> Get(long id)
    {
        var user = await _users
            .Include(x => x.Favorites)
            .Include(x => x.Publications)
            .Include(x => x.UserRole)
            .FirstOrDefaultAsync();

        return user;
    }

    public async Task<User?> GetByUsername(string name)
    {
        var user = await _users.Include(x => x.UserRole)
            .FirstOrDefaultAsync(x => x.Username == name);

        return user;
    }

    public async Task Update(User entity)
    {
        var user = await _users.FirstAsync(x => x.Id == entity.Id);

        user.Surname = entity.Surname;
        user.Username = entity.Username;
        user.IsDisabled = entity.IsDisabled;
        user.Favorites = entity.Favorites;
        user.Publications = entity.Publications;
        user.UserRole = entity.UserRole;
        user.Firstname = entity.Firstname;
        user.PasswordHash = entity.PasswordHash;

        await _context.SaveChangesAsync();
    }
}
