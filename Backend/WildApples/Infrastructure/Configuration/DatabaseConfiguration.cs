using Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options 
                => options.UseNpgsql(DependencyInjectionOptions.CONNECTION_STRING));

            return services;
        }
    }
}
