using Ardalis.GuardClauses;
using Domain.Entities;
using Domain.Models.UpdateDTOs;
using Domain.Repositories;

namespace Domain.Services
{
    public class UserService(IUserRepository userRepository)
    {
        public async Task<long> Add(User entity)
        {
            await userRepository.Add(entity);
            return entity.Id;
        }

        public async Task<User> Get(long id)
        {
            var user = await userRepository.Get(id);
            Guard.Against.NotFound(id, user);

            return user;
        }

        public async Task Delete(long id)
        {
            var user = await Get(id);

            user.IsDisabled = true;
            await userRepository.Update(user);
        }

        public async Task Update(UserUpdateDTO updateDto)
        {
            var user = await Get(updateDto.Id);

            user.Publications = updateDto.Publications;
            user.Username = updateDto.Username;
            user.PasswordHash = updateDto.PasswordHash;
            user.Firstname = updateDto.Firstname;
            user.Surname = updateDto.Surname;
            user.Favorites = updateDto.Favorites;
            user.UserRole = updateDto.UserRole;
            user.IsDisabled = updateDto.IsDisabled;

            await userRepository.Update(user);
        }
    }
}
