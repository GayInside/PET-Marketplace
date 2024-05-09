﻿using Ardalis.GuardClauses;
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
            publication.UsersWhoLiked = updateDto.UsersWhoLiked;
            publication.Title = updateDto.Title;
            publication.Description = updateDto.Description;
            publication.Owner = updateDto.Owner;
            publication.ImageUrls = updateDto.ImageUrls;
            publication.IsDisabled = updateDto.IsDisabled;

            await publicationRepository.Update(publication);
        }

        public async Task<IEnumerable<Publication>> GetItems(PublicationPaginationParams filter)
        {
            var items = await publicationRepository.GetItems(filter);

            return items;
        }
    }
}
