using AchievementsMicroservice.Data.Entities;
using AchievementsMicroservice.DTOs;
using AchievementsMicroservice.Models;

namespace AchievementsMicroservice.Interfaces
{
    public interface IAchievementRepository
    {
        public IEnumerable<AchievementDTO> GetAchievements();
        public IEnumerable<UserAchievementDTO> GetAchievements(int userId);
        public void SaveAchievement(int userId, int achievementId);
    }
}
