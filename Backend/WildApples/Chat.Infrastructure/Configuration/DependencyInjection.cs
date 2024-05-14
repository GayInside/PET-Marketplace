using Microsoft.Extensions.DependencyInjection;

namespace Chat.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDatabase();
            services.AddRepositories();

            return services;
        }
    }
}
