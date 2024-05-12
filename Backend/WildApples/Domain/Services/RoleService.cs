using Ardalis.GuardClauses;
using Domain.Entities;
using Domain.Models.UpdateDTOs;
using Domain.Repositories;
using Domain.Utils;

namespace Domain.Services
{
    public class RoleService(IRoleRepository roleRepository)
    {
        public async Task<long> Add(Role entity)
        {
            await roleRepository.Add(entity);
            return entity.Id;
        }

        public async Task<Role> Get(long id)
        {
            var role = await roleRepository.Get(id);
            Guard.Against.NotFound(id, role);

            return role;
        }

        public async Task Delete(long id)
        {
            var role = await Get(id);

            role.IsDisabled = true;
            await roleRepository.Update(role);
        }

        public async Task Update(RoleUpdateDTO updateDto)
        {
            var role = await Get(updateDto.Id);

            role.UsersWithRole = updateDto.UsersWithRole;
            role.Name = updateDto.Name;
            role.IsDisabled = updateDto.IsDisabled;

            await roleRepository.Update(role);
        }

        public async Task<Role> GetDefaultRole()
        {
            var role = await roleRepository.GetByName(RolesScheme.DEFAULT_USER_ROLE);
            Guard.Against.NotFound(RolesScheme.DEFAULT_USER_ROLE, role);

            return role;
        }
    }
}
