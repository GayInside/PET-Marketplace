using Infrastructure.APIs.ChatAPI;
using MediatR;
using Web.Models.Commands.Chat;

namespace Web.Handlers.Chat
{
    public class CreateChatCommandHandler(ChatAPI chatAPI)
        : IRequestHandler<CreateChatCommand, long?>
    {
        public async Task<long?> Handle(CreateChatCommand request, CancellationToken cancellationToken)
        {
            var chatDto = new ChatDTO()
            {
                FirstUserId = request.FirstUserId,
                SecondUserId = request.SecondUserId
            };
            var id = await chatAPI.CreateChat(chatDto);

            return id;
        }
    }
}
