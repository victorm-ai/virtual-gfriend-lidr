using AchievementsMicroservice.DTOs;
using AchievementsMicroservice.Interfaces;
using AchievementsMicroservice.Models;

namespace AchievementsMicroservice.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRepository _AchievementRepository;

        public AchievementService(IAchievementRepository achievementRepository) 
        {
            _AchievementRepository = achievementRepository;
        }

        public void SaveAchievement(int userId, int achievementId)
        {
            _AchievementRepository.SaveAchievement(userId, achievementId);
        }

        public IEnumerable<UserAchievementDTO> GetAchievements(int userId)
        {
            return _AchievementRepository.GetAchievements(userId);
        }

        public IEnumerable<AchievementDTO> GetAchievements()
        {
            return _AchievementRepository.GetAchievements();
        }
    }
}
