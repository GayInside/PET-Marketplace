using MediatR;

namespace Web.Models.Commands.Chat
{
    public record CreateChatCommand : IRequest<long?>
    {
        public long FirstUserId { get; init; }

        public long SecondUserId { get; init; }
    }
}
