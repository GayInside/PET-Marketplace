using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Minio;

namespace Infrastructure.Configuration
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<IFileStorageRepository, FileStorageRepository>();

            services.AddMinio(configureClient => configureClient
            .WithEndpoint(InfrastructureDIOptions.MINIO_ENDPOINT)
            .WithCredentials(InfrastructureDIOptions.MINIO_ACCSESS, InfrastructureDIOptions.MINIO_SECRET));

            return services;
        }
    }
}
