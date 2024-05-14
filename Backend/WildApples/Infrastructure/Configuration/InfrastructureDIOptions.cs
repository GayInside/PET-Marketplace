namespace Infrastructure.Configuration
{
    public class InfrastructureDIOptions
    {
        public static string CONNECTION_STRING { get; set; } = null!;
        public static string MINIO_ACCSESS { get; set; } = null!;
        public static string MINIO_SECRET { get; set; } = null!;
        public static string MINIO_ENDPOINT { get; set; } = null!;
    }
}
