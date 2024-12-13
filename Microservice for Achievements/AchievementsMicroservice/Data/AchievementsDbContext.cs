using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using AchievementsMicroservice.Data.Entities;
using AchievementsMicroservice.Interfaces;

namespace AchievementsMicroservice.Data
{
    public class AchievementsDbContext: DbContext
    {
        public IConfiguration appConfig;

        public DbSet<AchievementEntity> Achievements { get; set; }
        public DbSet<UserAchievementsEntity> UserAchievements { get; set; }

        public AchievementsDbContext(IConfiguration config) 
        {
            appConfig = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(appConfig.GetConnectionString("Virtual_Girlfriend"));
        }
    }
}
