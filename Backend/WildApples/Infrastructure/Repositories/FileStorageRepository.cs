using Domain.Repositories;
using Minio;
using Minio.DataModel.Args;

namespace Infrastructure.Repositories
{
    public class FileStorageRepository(IMinioClient minioClient) : IFileStorageRepository
    {
        public async Task<string?> GetPresignedUrlForSavingPublicationsLogo(string? logoName)
        {
            PresignedPutObjectArgs args = new PresignedPutObjectArgs()
                .WithBucket("publications")
                .WithObject(logoName)
                .WithExpiry(60 * 60 * 24);

            var generatedLink = await minioClient.PresignedPutObjectAsync(args);
            return generatedLink;
        }

        public async Task<string?> GetPresignedUrlForRetrivingPublicationsLogo(string? logoName)
        {
            PresignedGetObjectArgs args = new PresignedGetObjectArgs()
                .WithBucket("publications")
                .WithObject(logoName)
                .WithExpiry(60 * 60 * 24);

            var generatedLink = await minioClient.PresignedGetObjectAsync(args);
            return generatedLink;
        }
    }
}
