using Chat.Domain.Repositories;
using Chat.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Infrastructure.Configuration
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
