using MediatR;

namespace Web.Models.Commands.Authorization
{
    public record CreateAccountCommand : IRequest
    {
        public string Username { get; init; } = null!;

        public string Password { get; init; } = null!;

        public string Firstname { get; init; } = null!;

        public string Surname { get; init; } = null!;
    }
}
