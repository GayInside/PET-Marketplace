using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<AccountService>();
            services.AddScoped<HashService>();

            return services;
        }
    }
}
