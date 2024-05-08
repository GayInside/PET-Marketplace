using Domain.Configuration;
using Infrastructure.Configuration;
using Web.Configuration;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.SetUpInfrastructureConfiguration();

            // Add layers services
            builder.Services.AddWebServices();
            builder.Services.AddDomainServices();
            builder.Services.AddInfrastructureServices();
            // Services

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
