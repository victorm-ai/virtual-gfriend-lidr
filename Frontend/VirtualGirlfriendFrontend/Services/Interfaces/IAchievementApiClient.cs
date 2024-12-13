using VirtualGirlfriendFrontend.Models.DTOs;

namespace VirtualGirlfriendFrontend.Services.Interfaces
{
    public interface IAchievementsApiClient
    {
        Task<IEnumerable<AchievementDTO>> GetAchievementsAsync();
        Task<IEnumerable<AchievementDTO>> GetUserAchievementsAsync(int userId);
        Task<bool> SaveAchievementAsync(int userId, int achievementId);
    }
}
