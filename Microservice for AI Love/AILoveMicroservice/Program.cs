using AILoveMicroservice.Data;
using AILoveMicroservice.Data.Repositories;
using AILoveMicroservice.Interfaces;
using AILoveMicroservice.Services;

namespace AILoveMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IAILoveService, AILoveService>();
            builder.Services.AddSingleton<IAILoveRepository, AILoveRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
