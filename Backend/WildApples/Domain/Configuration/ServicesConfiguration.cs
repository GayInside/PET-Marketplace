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
            services.AddScoped<CategoryService>();
            services.AddScoped<PublicationService>();
            services.AddScoped<RoleService>();
            services.AddScoped<UserService>();
            services.AddScoped<SubcategoryService>();
            services.AddScoped<ContextService>();

            return services;
        }
    }
}
