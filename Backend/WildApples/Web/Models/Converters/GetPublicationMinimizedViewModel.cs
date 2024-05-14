using Domain.Entities;
using Web.Models.ViewModels.Publication;

namespace Web.Models.Converters
{
    public static class GetPublicationMinimizedViewModel
    {
        public static PublicationMinimiziedViewModel From(Publication publication)
        {
            return new()
            { 
                Id = publication.Id,
                Title = publication.Title
            };
        }
    }
}
