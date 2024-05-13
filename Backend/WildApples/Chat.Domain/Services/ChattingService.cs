using Ardalis.GuardClauses;
using Chat.Domain.Entities;
using Chat.Domain.Models;
using Chat.Domain.Repositories;

namespace Chat.Domain.Services
{
    public class ChattingService(IChatRepository chatRepository, IMessageRepository messageRepository, IUserRepository userRepository)
    {
        public async Task<List<Message>?> GetLastMessages(long id)
        {
            var chat = await chatRepository.Get(id);        
            if(chat is null)
            {
                return null;
            }


            return chat.MessagesInChat?
                .OrderByDescending(x => x.Id)
                .Take(10)
                .Reverse()
                .ToList() ?? new List<Message>();
        }

        public async Task AddMessage(AddMessageDTO dto)
        {
            var user = await userRepository.GetByUsername(dto.Username);
            Guard.Against.NotFound(dto.Username, user);

            var message = new Message()
            {
                User = user,
                Content = dto.Content,
                Chat = await chatRepository.Get(dto.ChatId) ?? throw new ArgumentNullException("No such chat")
            };

            await messageRepository.Add(message);
        }

        public async Task<Domain.Entities.Chat?> GetChat(long id)
        {
            var chat = await chatRepository.Get(id);

            return chat;
        }

        public async Task<long> CreateChat(long firstId, long secondId)
        {
            var userFirst = await userRepository.Get(firstId);
            Guard.Against.NotFound(firstId, userFirst);
            var userSecond = await userRepository.Get(secondId);
            Guard.Against.NotFound(secondId, userSecond);

            var chat = new Domain.Entities.Chat()
            {
                UsersInChat = [userFirst, userSecond]
            };

            await chatRepository.Add(chat);
            return chat.Id;
        }
    }
}
