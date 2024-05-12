using Domain.Models;
using Domain.Services;
using MediatR;
using Web.Models.Commands.Authorization;

namespace Web.Handlers.Authorization
{
    public class CreateAccountCommandHandler(AccountService accountService)
        : IRequestHandler<CreateAccountCommand>
    {
        public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var createModel = new CreateUserModel()
            {
                Firstname = request.Firstname,
                Surname = request.Surname,
                Username = request.Username,
                Password = request.Password
            };

            try
            {
                await accountService.CreateUser(createModel);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
