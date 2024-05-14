using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDatabase();
            services.AddRepositories();
            services.AddAPIs();

            return services;
        }
    }
}
