using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using AvatarsMicroservice.Data.Entities;
using AvatarsMicroservice.Interfaces;
using AvatarsMicroservice.Data.Entities;

namespace AvatarsMicroservice.Data
{
    public class AvatarsDbContext: DbContext
    {
        public IConfiguration appConfig;

        public DbSet<AvatarEntity> Avatars { get; set; }

        public AvatarsDbContext(IConfiguration config) 
        {
            appConfig = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(appConfig.GetConnectionString("Virtual_Girlfriend"));
        }
    }
}
