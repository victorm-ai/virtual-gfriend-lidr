using ActivitiesMicroservice.Data.Entities;
using ActivitiesMicroservice.DTOs;
using ActivitiesMicroservice.Models;

namespace ActivitiesMicroservice.Interfaces
{
    public interface IActivityRepository
    {
        public IEnumerable<ActivityDTO> GetActivities(int userId);
        public void SaveActivity(ActivityDTO activity);
        public void UpdateActivity(int userId, int activityId, ActivityDTO UpdateActivityRequest);
        public void DeleteActivity(int userId, int activityId);
    }
}
