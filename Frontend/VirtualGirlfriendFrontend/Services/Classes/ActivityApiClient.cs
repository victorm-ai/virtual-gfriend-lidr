using Newtonsoft.Json;
using System.Net.Http;
using VirtualGirlfriendFrontend.Models.DTOs;
using VirtualGirlfriendFrontend.Services.Interfaces;

namespace VirtualGirlfriendFrontend.Services.Classes
{
    public class ActivityApiClient : IActivityApiClient
    {
        private readonly HttpClient _httpClient;

        public ActivityApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ActivityDTO>> GetActivitiesAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"GetActivities/{userId}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ActivityDTO>>(response.Content.ReadAsStringAsync().Result);
            }

            return null;
        }

        public async Task<bool> SaveActivityAsync(ActivityDTO activity)
        {
            var response = await _httpClient.PostAsJsonAsync($"SaveActivity", activity);
            return response.IsSuccessStatusCode;
        }

        // PUT: UpdateActivity/{userId}/{activityId}
        public async Task<bool> UpdateActivityAsync(int activityId, ActivityDTO activity)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateActivity/{activity.UserId}/{activityId}", activity);
            return response.IsSuccessStatusCode;
        }

        // DELETE: DeleteActivity/{userId}/{activityId}
        public async Task<bool> DeleteActivityAsync(int userId, int activityId)
        {
            var response = await _httpClient.DeleteAsync($"DeleteActivity/{userId}/{activityId}");
            return response.IsSuccessStatusCode;
        }
    }
}
