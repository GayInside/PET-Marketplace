using Ardalis.GuardClauses;
using Domain.Models;
using Domain.Repositories;

namespace Domain.Services
{
    public class AccountService(IUserRepository _repository, HashService hashService)
    {
        public async Task<AccountModel> GetAccountModel(UserCredentials credentials)
        {
            var user = await _repository.GetByUsername(credentials.Username);

            Guard.Against.NotFound(credentials.Username, user);

            if (user.PasswordHash != hashService.GetHash(credentials.Password))
            {
                throw new Exception("Invalid data input");
            }

            var accountModel = new AccountModel()
            {
                Username = user.Username,
                Role = user.UserRole
            };

            return accountModel;
        }
    }
}
