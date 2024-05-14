using Chat.Domain.Configuration;
using Chat.Infrastructure.Configuration;
using Chat.Web.Configuration;
using Chat.Web.Middleware;

namespace Chat.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.SetUpInfrastructureConfiguration();

            builder.Services.AddDomainServices();
            builder.Services.AddInfrastructureServices();
            builder.Services.AddWebServices();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.MapControllers();
            app.UseCors();
            app.UseMiddleware<AuthMiddleware>();
            app.Run();
        }
    }
}
