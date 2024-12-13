using InteractionsMicroservice.Data;
using InteractionsMicroservice.Data.Repositories;
using InteractionsMicroservice.Interfaces;
using InteractionsMicroservice.Services;

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
            builder.Services.AddSingleton<IInteractionService, InteractionService>();
            builder.Services.AddSingleton<IInteractionRepository, InteractionRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
