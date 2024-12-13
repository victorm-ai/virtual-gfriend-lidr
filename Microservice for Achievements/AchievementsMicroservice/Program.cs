using AchievementsMicroservice.Data;
using AchievementsMicroservice.Data.Repositories;
using AchievementsMicroservice.Interfaces;
using AchievementsMicroservice.Services;

namespace UsersMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IAchievementService, AchievementService>();
            builder.Services.AddSingleton<IAchievementRepository, AchievementRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
