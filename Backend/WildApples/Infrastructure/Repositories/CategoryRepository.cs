using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbSet<Category> _categories = null!;
        private readonly ApplicationContext _context = null!;

        public CategoryRepository(ApplicationContext context)
        {
            _categories = context.Categories;
            _context = context;
        }

        public async Task Add(Category entity)
        {
            await _categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Category entity)
        {
            _categories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Category?> Get(long id)
        {
            var category = await _categories
                .Include(x => x.Subcategories)
                .SingleOrDefaultAsync(x => x.Id == id);

            return category;
        }

        public async Task Update(Category entity)
        {
            var category = await _categories.FirstAsync(x => x.Id == entity.Id);

            category.Title = entity.Title;
            category.Subcategories = entity.Subcategories;
            category.IsDisabled = entity.IsDisabled;

            await _context.SaveChangesAsync();
        }
    }
}
