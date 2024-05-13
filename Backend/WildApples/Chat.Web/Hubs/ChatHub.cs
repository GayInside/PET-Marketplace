using Chat.Domain.Models;
using Chat.Domain.Services;
using Chat.Web.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Web.Hubs
{
    public class ChatHub(ChattingService chattingService) : Hub
    {
        public async Task SendMessage(MessageViewModel message)
        {
            var dto = new AddMessageDTO()
            {
                ChatId = message.ChatId,
                Content = message.Content,
                Username = message.Username
            };

            await chattingService.AddMessage(dto);
            await Clients.All.SendAsync("ServerGotOneNewMessage", message.Username, message.Content, message.ChatId);
        }

        public async Task GetLastMessages(long chatId)
        {
            var lastMessages = await chattingService.GetLastMessages(chatId);
            await Clients.Caller.SendAsync("LastMessages", lastMessages);
        }
    }
}
                                        