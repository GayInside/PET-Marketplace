using Domain.Entities;
using Domain.Models.PaginationParams;
using Domain.Repositories;
using Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PublicationRepository : IPublicationRepository
    {
        private readonly DbSet<Publication> _publications = null!;
        private readonly ApplicationContext _context = null!;

        public PublicationRepository(ApplicationContext context)
        {
            _publications = context.Publications;
            _context = context;
        }

        public async Task Add(Publication entity)
        {
            await _publications.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Publication entity)
        {
            _publications.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Publication?> Get(long id)
        {
            var publication = await _publications
                .Include(x => x.Subcategories)
                .Include(x => x.Owner)
                .Include(x => x.UsersWhoLiked)
                .FirstOrDefaultAsync();

            return publication;
        }

        public async Task<IEnumerable<Publication>> GetItems(PublicationPaginationParams filter)
        {
            var itemsQuery = _publications
                .Include(x => x.Subcategories)
                .OrderBy(x => x.Id)
                .Where(x => !x.IsDisabled);

            if (filter.Subcategory is not null)
            {
                itemsQuery = itemsQuery.Where(x => x.Subcategories.First().Id == filter.Subcategory.Id);
            }

            itemsQuery = itemsQuery
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            var items = await itemsQuery.ToListAsync();

            foreach (var item in items)
            {
                Console.WriteLine(item.Title);
            }

            return items.AsEnumerable();
        }

        public async Task Update(Publication entity)
        {
            var publication = await _publications.FirstAsync(x => x.Id == entity.Id);

            publication.Title = entity.Title;
            publication.Subcategories = entity.Subcategories;
            publication.IsDisabled = entity.IsDisabled;
            publication.Owner = entity.Owner;
            publication.UsersWhoLiked = entity.UsersWhoLiked;
            publication.Description = entity.Description;
            publication.ImageUrls = entity.ImageUrls;

            await _context.SaveChangesAsync();
        }
    }
}
