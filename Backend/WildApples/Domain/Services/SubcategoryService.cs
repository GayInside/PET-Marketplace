using Ardalis.GuardClauses;
using Domain.Entities;
using Domain.Models.UpdateDTOs;
using Domain.Repositories;

namespace Domain.Services
{
    public class SubcategoryService(ISubcategoryRepository subcategoryRepository)
    {
        public async Task<long> Add(Subcategory entity)
        {
            await subcategoryRepository.Add(entity);
            return entity.Id;
        }

        public async Task<Subcategory> Get(long id)
        {
            var subcategory = await subcategoryRepository.Get(id);
            Guard.Against.NotFound(id, subcategory);

            return subcategory;
        }

        public async Task Delete(long id)
        {
            var subcategory = await Get(id);

            subcategory.IsDisabled = true;
            await subcategoryRepository.Update(subcategory);
        }

        public async Task Update(SubcategoryUpdateDTO updateDto)
        {
            var subcategory = await Get(updateDto.Id);

            subcategory.Publications = updateDto.Publications;
            subcategory.Title = updateDto.Title;
            subcategory.Category = updateDto.Category;
            subcategory.IsDisabled = updateDto.IsDisabled;

            await subcategoryRepository.Update(subcategory);
        }
    }
}
