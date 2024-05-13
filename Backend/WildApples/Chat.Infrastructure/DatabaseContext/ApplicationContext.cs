using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.DatabaseContext
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Entities.Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SetUpEntities(builder);
        }

        private void SetUpEntities(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany(x => x.Chats)
                .WithMany(x => x.UsersInChat);

            builder
                .Entity<Domain.Entities.Chat>()
                .HasMany(x => x.MessagesInChat)
                .WithOne(x => x.Chat)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<Message>()
                .HasOne(x => x.User)
                .WithMany(x => x.Messages)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
