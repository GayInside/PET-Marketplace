using Infrastructure.DataBaseContext;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            var connectionString = EnvFetcher.GetRequiredEnvVariable("CONNECTION_STRING");
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));

            return services;
        }
    }
}
