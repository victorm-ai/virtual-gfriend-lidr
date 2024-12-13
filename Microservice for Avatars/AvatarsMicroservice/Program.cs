using AvatarsMicroservice.Data;
using AvatarsMicroservice.Data.Repositories;
using AvatarsMicroservice.Interfaces;
using AvatarsMicroservice.Services;
using AvatarsMicroservice.Interfaces;

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
            builder.Services.AddSingleton<IAvatarService, AvatarService>();
            builder.Services.AddSingleton<IAvatarRepository, AvatarRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
