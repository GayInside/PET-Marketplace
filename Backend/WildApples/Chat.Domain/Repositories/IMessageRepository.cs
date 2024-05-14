using Chat.Domain.Entities;

namespace Chat.Domain.Repositories
{
    public interface IMessageRepository
    {
        public Task<long> Add(Domain.Entities.Message message);

        public Task<Domain.Entities.Message?> Get(long id);
    }
}
