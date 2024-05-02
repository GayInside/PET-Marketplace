namespace Infrastructure.Helpers
{
    internal static class EnvFetcher
    {
        private static string? GetEnvVariable(string variableName)
        {
            var envVar = Environment.GetEnvironmentVariable(variableName);
            return envVar;
        }

        public static string GetRequiredEnvVariable(string variableName)
        {
            return GetEnvVariable(variableName) ?? throw new Exception($"No {variableName} provided");
        }
    }
}
