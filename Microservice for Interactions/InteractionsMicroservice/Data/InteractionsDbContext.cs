using InteractionsMicroservice.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractionsMicroservice.Data
{
    public class InteractionsDbContext : DbContext
    {
        public IConfiguration appConfig;

        public DbSet<InteractionEntity> Interactions { get; set; }

        public InteractionsDbContext(IConfiguration config)
        {
            appConfig = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(appConfig.GetConnectionString("Virtual_Girlfriend"));
        }
    }
}
