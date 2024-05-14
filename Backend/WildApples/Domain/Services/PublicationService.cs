using Ardalis.GuardClauses;
using Domain.Entities;
using Domain.Models.PaginationParams;
using Domain.Models.UpdateDTOs;
using Domain.Repositories;

namespace Domain.Services
{
    public class PublicationService(IPublicationRepository publicationRepository)
    {
        public async Task<long> Add(Publication entity)
        {
            await publicationRepository.Add(entity);

            return entity.Id;
        }

        public async Task<Publication> Get(long id)
        {
            var publication = await publicationRepository.Get(id);
            Guard.Against.NotFound(id, publication);

            return publication;
        }

        public async Task Delete(long id)
        {
            var publication = await Get(id);

            publication.IsDisabled = true;
            await publicationRepository.Update(publication);
        }

        public async Task Update(PublicationUpdateDTO updateDto)
        {
            var publication = await Get(updateDto.Id);

            publication.Subcategories = updateDto.Subcategories;
            publication.Title = updateDto.Title;
            publication.Description = updateDto.Description;

            await publicationRepository.Update(publication);
        }

        public async Task<IEnumerable<Publication>> GetItems(PublicationPaginationParams filter)
        {
            var items = await publicationRepository.GetItems(filter);

            return items;
        }

        public async Task AddToFavorites(User user, long publicationId)
        {
            var publication = await publicationRepository.GetWithUserWhoLiked(publicationId);
            Guard.Against.NotFound(publicationId, publication);

            if (publication.UsersWhoLiked is null)
            {
                publication.UsersWhoLiked = new List<User>();
            }

            publication.UsersWhoLiked.Add(user);
            await publicationRepository.Update(publication);
        }
    }
}
