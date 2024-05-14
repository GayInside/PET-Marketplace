using Domain.Models;
using Domain.Services;
using Infrastructure.APIs.ChatAPI;
using MediatR;
using Web.Models.Commands.Authorization;

namespace Web.Handlers.Authorization
{
    public class CreateAccountCommandHandler(AccountService accountService, ChatAPI chatAPI)
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
                var id = await accountService.CreateUser(createModel);
                var createUserDto = new UserDTO()
                {
                    MainId = id,
                    Username = request.Username
                };

                await chatAPI.AddUserToApi(createUserDto);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
