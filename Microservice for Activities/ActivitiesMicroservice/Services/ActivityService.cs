using ActivitiesMicroservice.DTOs;
using ActivitiesMicroservice.Interfaces;
using ActivitiesMicroservice.Models;

namespace ActivitiesMicroservice.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _ActivityRepository;

        public ActivityService(IActivityRepository activityRepository) 
        {
            _ActivityRepository = activityRepository;
        }

        public void DeleteActivity(int userId, int activityId)
        {
            _ActivityRepository.DeleteActivity(userId, activityId); 
        }

        public IEnumerable<ActivityDTO> GetActivities(int userId)
        {
           return _ActivityRepository.GetActivities(userId);
        }

        public void SaveActivity(ActivityDTO activity)
        {
            _ActivityRepository.SaveActivity(activity);
        }

        public void UpdateActivity(int userId, int activityId, ActivityDTO UpdateActivityRequest)
        {
            _ActivityRepository.UpdateActivity(userId, activityId, UpdateActivityRequest);
        }
    }
}
