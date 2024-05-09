using Domain.Models;
using MediatR;

namespace Web.Models.Commands.Authorization
{
    public record LoginCommand
        : IRequest<AccountModel>
    {
        public string Username { get; init; } = null!;

        public string Password { get; init; } = null!;
    }
}
