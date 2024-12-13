using ActivitiesMicroservice.Data;
using ActivitiesMicroservice.Data.Repositories;
using ActivitiesMicroservice.Interfaces;
using ActivitiesMicroservice.Services;

namespace ActivitiesMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IActivityService, ActivityService>();
            builder.Services.AddSingleton<IActivityRepository, ActivityRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
