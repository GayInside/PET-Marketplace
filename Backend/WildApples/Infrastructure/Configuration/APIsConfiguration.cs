using Infrastructure.APIs.ChatAPI;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class APIsConfiguration
    {
        public static IServiceCollection AddAPIs(this IServiceCollection services)
        {
            services.AddScoped<ChatAPI>();

            return services;
        }
    }
}
