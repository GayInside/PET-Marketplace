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

            builder.Services.AddDomainServices();
            builder.Services.AddInfrastructureServices();
            builder.Services.AddWebServices();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
