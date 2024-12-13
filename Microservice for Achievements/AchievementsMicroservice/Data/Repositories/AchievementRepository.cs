using AchievementsMicroservice.Data.Entities;
using AchievementsMicroservice.DTOs;
using AchievementsMicroservice.Interfaces;
using AchievementsMicroservice.Models;

namespace AchievementsMicroservice.Data.Repositories
{
    public class AchievementRepository : IAchievementRepository
    {
        private readonly AchievementsDbContext _AchievementsDbContext;

        public AchievementRepository()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                          .Build();

            _AchievementsDbContext = new AchievementsDbContext(configuration);
        }

        public void SaveAchievement(int userId, int achievementId)
        {
            try
            {
                var newAchievement = new UserAchievementsEntity()
                {
                     UserId = userId,
                      AchievementId = achievementId,
                       Timestamp = DateTime.UtcNow
                };

                _AchievementsDbContext.UserAchievements.Add(newAchievement);
                _AchievementsDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<UserAchievementDTO> GetAchievements(int userId)
        {
            try
            {
                var userAchievementsList = new List<UserAchievementDTO>();

                var result = _AchievementsDbContext.UserAchievements.Where(ua => ua.UserId == userId).ToList();

                if (result != null)
                {
                    result.ForEach(ua => userAchievementsList.Add(new UserAchievementDTO
                    {
                        UserId = ua.UserId,
                        AchievementId = ua.AchievementId,
                        Id = ua.Id
                    }));

                    return userAchievementsList;

                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<AchievementDTO> GetAchievements()
        {
            var achievementsList = new List<AchievementDTO>();

            try
            {
                var result = _AchievementsDbContext.Achievements.ToList();

                if (result != null)
                {
                    result.ForEach(a => achievementsList.Add(new AchievementDTO { Id = a.Id, Name = a.Name, Description = a.Description, Rank = a.Rank}));

                    return achievementsList;
                }

                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }      
    }
}
