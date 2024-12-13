using System.Net.Http.Headers;
using System.Net.Http;
using VirtualGirlfriendFrontend.Services.Classes;
using VirtualGirlfriendFrontend.Services.Interfaces;

namespace VirtualGirlfriendFrontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddHttpClient<IUserApiClient, UserApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7005/api/users/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            builder.Services.AddHttpClient<IAvatarApiClient, AvatarApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7007/api/avatars/");
            });

            builder.Services.AddHttpClient<IActivityApiClient, ActivityApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7009/api/activities/");
                // Ajustar la URL base según tu backend real
            });

            builder.Services.AddHttpClient<IAchievementsApiClient, AchievementApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7011/api/achievements/");
            });

            builder.Services.AddHttpClient<IAILoveApiClient, AILoveApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7013/api/ailove/");
            });



            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20); 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
