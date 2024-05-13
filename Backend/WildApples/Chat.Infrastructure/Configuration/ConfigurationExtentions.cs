using Microsoft.Extensions.Configuration;

namespace Chat.Infrastructure.Configuration
{
    public static class ConfigurationExtentions
    {
        public static IConfiguration SetUpInfrastructureConfiguration(this IConfiguration configuration)
        {
            InfrastructureDIOptions.CONNECTION_STRING = configuration.GetConnectionString("PostgresConnectionString")
                ?? throw new ArgumentNullException("NO CONECTION STRING PROVIDED");

            return configuration;
        }
    }
}
