using Chat.Domain.Entities;
using Chat.Domain.Repositories;
using Chat.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repositories
{
    public class ChatRepository
        : IChatRepository
    {
        private readonly DbSet<Domain.Entities.Chat> _chats;
        private readonly ApplicationContext _context;

        public ChatRepository(ApplicationContext context)
        {
            _chats = context.Chats;
            _context = context;
        }

        public async Task<long> Add(Domain.Entities.Chat chat)
        {
            await _chats.AddAsync(chat);
            await _context.SaveChangesAsync();

            return chat.Id;
        }

        public async Task<Domain.Entities.Chat?> Get(long id)
        {
            return await _chats
                .Include(x => x.UsersInChat)
                .Include(x => x.MessagesInChat)
                .SingleOrDefaultAsync(chat => chat.Id == id);
        }

        //public async Task<List<Message>?> GetLastMessages(long id)
        //{
        //    var chat = await Get(id);

        //    chat.MessagesInChat
        //}
    }
}
