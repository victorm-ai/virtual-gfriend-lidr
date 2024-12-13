using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ActivitiesMicroservice.Data.Entities;
using ActivitiesMicroservice.Interfaces;

namespace ActivitiesMicroservice.Data
{
    public class ActivitiesDbContext : DbContext
    {
        public IConfiguration appConfig;

        public DbSet<ActivityEntity> Activities { get; set; }

        public ActivitiesDbContext(IConfiguration config) 
        {
            appConfig = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(appConfig.GetConnectionString("Virtual_Girlfriend"));
        }
    }
}
