using Chat.Domain.Entities;
using Chat.Domain.Repositories;

namespace Chat.Domain.Services
{
    public class UserService(IUserRepository userRepository)
    {
        public async Task<long> Add(User user)
        {
            await userRepository.Add(user);

            return user.Id;
        }
    }
}
