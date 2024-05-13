namespace Chat.Domain.Repositories
{
    public interface IChatRepository
    {
        public Task<Domain.Entities.Chat?> Get(long id);

        public Task<long> Add(Domain.Entities.Chat chat);
    }
}
