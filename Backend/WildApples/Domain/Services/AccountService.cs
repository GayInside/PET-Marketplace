using Ardalis.GuardClauses;
using Domain.Models;
using Domain.Repositories;

namespace Domain.Services
{
    public class AccountService(IUserRepository _repository, HashService hashService, RoleService roleService)
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

        public async Task CreateUser(CreateUserModel userModel)
        {
            var userExist = await _repository.GetByUsername(userModel.Username) is not null;
            if (userExist)
            {
                throw new Exception("Such username is unavalible");
            }

            var user = new Domain.Entities.User()
            {
                Username = userModel.Username,
                PasswordHash = hashService.GetHash(userModel.Password),
                Firstname = userModel.Firstname,
                Surname = userModel.Surname,
                UserRole = await roleService.GetDefaultRole()
            };

            await _repository.Add(user);
        }
    }
}
