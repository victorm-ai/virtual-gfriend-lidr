using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using AILoveMicroservice.Data.Entities;
using AILoveMicroservice.Interfaces;

namespace AILoveMicroservice.Data
{
    public class AILoveDbContext : DbContext
    {
        public IConfiguration appConfig;

        public DbSet<AILoveEntity> Users { get; set; }

        public AILoveDbContext(IConfiguration config) 
        {
            appConfig = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(appConfig.GetConnectionString("Virtual_Girlfriend"));
        }
    }
}
