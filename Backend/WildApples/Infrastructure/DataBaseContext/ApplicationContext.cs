using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataBaseContext
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SetUpEntities(builder);           
        }

        private void SetUpEntities(ModelBuilder builder)
        {
            builder
                .Entity<Category>()
                .HasMany(c => c.Subcategories)
                .WithOne(s => s.Category)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<Publication>()
                .HasMany(p => p.Subcategories)
                .WithMany(s => s.Publications);

            builder
                .Entity<Publication>()
                .HasOne(p => p.Owner)
                .WithMany(u => u.Publications)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<Publication>()
                .HasMany(p => p.UsersWhoLiked)
                .WithMany(u => u.Favorites);

            builder
                .Entity<Role>()
                .HasMany(x => x.UsersWithRole)
                .WithOne(x => x.UserRole)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
