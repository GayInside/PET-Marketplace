using Domain.Models;
using Domain.Services;
using MediatR;
using Web.Models.Authorization;

namespace Web.Handlers.Authorization;

public class LoginCommandHandler(AccountService accountService)
    : IRequestHandler<LoginCommand, AccountModel>
{
    public async Task<AccountModel> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var userCredentials = new UserCredentials()
        {
            Username = request.Username,
            Password = request.Password
        };

        try
        {
            var accountModel = await accountService.GetAccountModel(userCredentials);
            return accountModel;
        }
        catch(Exception) 
        {
            throw new Exception("Incorrect username or password");
        }
    }
}
