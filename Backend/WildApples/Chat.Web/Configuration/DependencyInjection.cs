namespace Chat.Web.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.SetIsOriginAllowed(url => true);
                    policy.AllowCredentials();
                });
            });
            services.AddSignalR();                

            return services;
        }
    }
}
