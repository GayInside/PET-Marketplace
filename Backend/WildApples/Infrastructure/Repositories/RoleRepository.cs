using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbSet<Role> _roles = null!;
        private readonly ApplicationContext _context = null!;

        public RoleRepository(ApplicationContext context)
        {
            _roles = context.Roles;
            _context = context;
        }

        public async Task Add(Role entity)
        {
            await _roles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Role entity)
        {
            _roles.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Role?> Get(long id)
        {
            var role = await _roles
                .Include(x => x.UsersWithRole)
                .SingleOrDefaultAsync(x => x.Id == id);

            return role;
        }

        public async Task<Role?> GetByName(string Name)
        {
            return await _roles.SingleOrDefaultAsync(x => x.Name == Name);
        }

        public async Task Update(Role entity)
        {
            var role = await _roles.FirstAsync(x => x.Id == entity.Id);

            role.Name = entity.Name;
            role.IsDisabled = entity.IsDisabled;
            role.UsersWithRole = entity.UsersWithRole;

            await _context.SaveChangesAsync();
        }
    }
}
