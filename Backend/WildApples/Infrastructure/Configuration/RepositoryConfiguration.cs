using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

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

            return services;
        }
    }
}
