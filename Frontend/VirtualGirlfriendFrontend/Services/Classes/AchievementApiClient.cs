using Newtonsoft.Json;
using VirtualGirlfriendFrontend.Models.DTOs;
using VirtualGirlfriendFrontend.Services.Interfaces;

namespace VirtualGirlfriendFrontend.Services.Classes
{
    public class AchievementApiClient : IAchievementsApiClient
    {
        private readonly HttpClient _httpClient;

        public AchievementApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AchievementDTO>> GetAchievementsAsync()
        {
            var result = await _httpClient.GetAsync("GetAchievements");

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<AchievementDTO>>(result.Content.ReadAsStringAsync().Result);
            }

            return null;
        }

        public async Task<IEnumerable<AchievementDTO>> GetUserAchievementsAsync(int userId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<AchievementDTO>>($"GetAchievements/{userId}");
        }

        public async Task<bool> SaveAchievementAsync(int userId, int achievementId)
        {
            var response = await _httpClient.PostAsync($"SaveAchievement/{userId}/{achievementId}", null);
            return response.IsSuccessStatusCode;
        }
    }
}
