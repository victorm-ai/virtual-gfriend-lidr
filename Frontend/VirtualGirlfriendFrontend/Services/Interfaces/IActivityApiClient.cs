using VirtualGirlfriendFrontend.Models.DTOs;

namespace VirtualGirlfriendFrontend.Services.Interfaces
{
    public interface IActivityApiClient
    {
        Task<IEnumerable<ActivityDTO>> GetActivitiesAsync(int userId);
        Task<bool> SaveActivityAsync(ActivityDTO activity);
        Task<bool> UpdateActivityAsync(int activityId, ActivityDTO activity);
        Task<bool> DeleteActivityAsync(int userId, int activityId);
    }
}
