using Ardalis.GuardClauses;
using Domain.Entities;
using Domain.Models.UpdateDTOs;
using Domain.Repositories;

namespace Domain.Services
{
    public class CategoryService(ICategoryRepository categoryRepository)
    {
        public async Task<long> Add(Category entity) 
        {
            await categoryRepository.Add(entity);

            return entity.Id;
        }

        public async Task<Category> Get(long id)
        {
            var category = await categoryRepository.Get(id);
            Guard.Against.NotFound(id, category);

            return category;
        }

        public async Task Delete(long id) 
        {
            var category = await Get(id);

            category.IsDisabled = true;
            await categoryRepository.Update(category);
        }

        public async Task Update(CategoryUpdateDto updateDto)
        {
            var category = await Get(updateDto.Id);

            category.Subcategories = updateDto.Subcategories;
            category.IsDisabled = updateDto.IsDisabled;
            category.Title = updateDto.Title;

            await categoryRepository.Update(category);
        }
    }
}
