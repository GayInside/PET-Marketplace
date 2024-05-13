using Chat.Domain.Repositories;
using Chat.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DbSet<Domain.Entities.Message> _messages;
        private readonly ApplicationContext _context;

        public MessageRepository(ApplicationContext context)
        {
            _messages = context.Messages;
            _context = context;
        }

        public async Task<long> Add(Domain.Entities.Message message)
        {
            await _messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return message.Id;
        }

        public async Task<Domain.Entities.Message?> Get(long id)
        {
            return await _messages
                .Include(x => x.Chat)
                .Include(x => x.User)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
    