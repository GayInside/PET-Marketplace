namespace Domain.Repositories
{
    public interface IFileStorageRepository
    {
        public Task<string?> GetPresignedUrlForSavingPublicationsLogo(string? logoName);

        public Task<string?> GetPresignedUrlForRetrivingPublicationsLogo(string? logoName);
    }
}
