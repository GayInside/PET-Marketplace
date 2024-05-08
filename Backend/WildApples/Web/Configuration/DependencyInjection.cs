using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

namespace Web.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                });

            return services;
        }
    }
}
