using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly DbSet<Subcategory> _subcategories = null!;
        private readonly ApplicationContext _context = null!;

        public SubcategoryRepository(ApplicationContext context)
        {
            _subcategories = context.Subcategories;
            _context = context;
        }

        public async Task Add(Subcategory entity)
        {
            await _subcategories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Subcategory entity)
        {
            _subcategories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Subcategory?> Get(long id)
        {
            var subcategory = await _subcategories
                .Include(x => x.Category)
                .Include(x => x.Publications)
                .SingleOrDefaultAsync(x => x.Id == id);

            return subcategory;
        }

        public async Task Update(Subcategory entity)
        {
            var subcategory = await _subcategories.FirstAsync(x => x.Id == entity.Id);

            subcategory.Title = entity.Title;
            subcategory.IsDisabled = entity.IsDisabled;
            subcategory.Publications = entity.Publications;
            subcategory.Category = entity.Category;

            await _context.SaveChangesAsync();
        }
    }
}
