using ActivitiesMicroservice.Data.Entities;
using ActivitiesMicroservice.DTOs;
using ActivitiesMicroservice.Interfaces;
using ActivitiesMicroservice.Models;

namespace ActivitiesMicroservice.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ActivitiesDbContext _ActivitiesDbContext;

        public ActivityRepository()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                          .Build();

            _ActivitiesDbContext = new ActivitiesDbContext(configuration);
        }

        public IEnumerable<ActivityDTO> GetActivities(int userId)
        {
            try
            {
                var result = _ActivitiesDbContext.Activities.Where(a => a.UserId == userId).ToList();

                if (result != null && result.Count>0)
                {
                    var activitiesList = new List<ActivityDTO>();

                    result.ForEach(a => activitiesList.Add(new ActivityDTO()
                    {
                        Name = a.Name,
                        UserId = a.UserId,
                        Timestamp = a.Timestamp,
                        WhenIs = a.WhenIs,
                        Id = a.Id,
                    })); 

                    return activitiesList;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void SaveActivity(ActivityDTO activity)
        {
            try
            {
                var newActivity = new ActivityEntity()
                {
                    UserId = activity.UserId,
                    Name = activity.Name,
                    Timestamp = DateTimeOffset.UtcNow,
                    WhenIs = activity.WhenIs,
                };

                _ActivitiesDbContext.Activities.Add(newActivity);
                _ActivitiesDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateActivity(int userId, int activityId, ActivityDTO UpdateActivityRequest)
        {
            try
            {
                var result = _ActivitiesDbContext.Activities.FirstOrDefault(a => a.UserId == userId && a.Id == activityId);

                if (result != null)
                {
                     result.Name = UpdateActivityRequest.Name;
                     result.Timestamp = DateTime.UtcNow;
                     result.WhenIs = UpdateActivityRequest.WhenIs;

                    _ActivitiesDbContext.Activities.Update(result);
                    _ActivitiesDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteActivity(int userId, int activityId)
        {
            try
            {
                var result = _ActivitiesDbContext.Activities.FirstOrDefault(a => a.UserId== userId && a.Id == activityId);

                if (result != null)
                {
                    _ActivitiesDbContext.Activities.Remove(result);
                    _ActivitiesDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
