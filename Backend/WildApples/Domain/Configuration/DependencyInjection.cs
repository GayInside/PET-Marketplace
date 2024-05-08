using Microsoft.Extensions.DependencyInjection;

namespace Domain.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }
    }
}
