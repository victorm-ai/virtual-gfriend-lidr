using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using UsersMicroservice.Data.Entities;
using UsersMicroservice.Interfaces;
using UsersMicroservice.Data.Entities;

namespace UsersMicroservice.Data
{
    public class UsersDbContext : DbContext
    {
        public IConfiguration appConfig;

        public DbSet<UserEntity> Users { get; set; }

        public UsersDbContext(IConfiguration config) 
        {
            appConfig = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(appConfig.GetConnectionString("Virtual_Girlfriend"));
        }
    }
}
