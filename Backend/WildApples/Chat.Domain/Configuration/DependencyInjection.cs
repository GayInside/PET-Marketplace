﻿using Chat.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Domain.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<AuthService>();

            return services;
        }
    }
}
