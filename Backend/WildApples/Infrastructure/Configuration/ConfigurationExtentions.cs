using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration
{
    public static class ConfigurationExtentions
    {
        public static IConfiguration SetUpInfrastructureConfiguration(this IConfiguration configuration)
        {
            InfrastructureDIOptions.CONNECTION_STRING = configuration.GetConnectionString("PostgresConnectionString")
                ?? throw new ArgumentNullException("NO CONECTION STRING PROVIDED");

            InfrastructureDIOptions.MINIO_ACCSESS = configuration.GetConnectionString("MINIO_ACCESS")
                ?? throw new ArgumentNullException("NO MINIO ACCESS PROVIDED");

            InfrastructureDIOptions.MINIO_SECRET = configuration.GetConnectionString("MINIO_SECRET")
                ?? throw new ArgumentNullException("NO MINIO SECRET PROVIDED");

            InfrastructureDIOptions.MINIO_ENDPOINT = configuration.GetConnectionString("MINIO_ENDPOINT")
                ?? throw new ArgumentNullException("NO MINIO ENDPOINT PROVIDED");

            return configuration;
        }
    }
}
