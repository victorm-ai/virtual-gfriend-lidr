using Newtonsoft.Json;
using VirtualGirlfriendFrontend.Models.DTOs;
using VirtualGirlfriendFrontend.Services.Interfaces;

namespace VirtualGirlfriendFrontend.Services.Classes
{
    public class AvatarApiClient : IAvatarApiClient
    {
        private readonly HttpClient _httpClient;

        public AvatarApiClient(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AvatarDTO>> GetAvatarsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<AvatarDTO>>("GetAvatars");
        }

        public async Task<AvatarDTO> GetAvatarAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<AvatarDTO>($"GetAvatar/{id}");
        }

        public async Task<bool> CreateAvatarAsync(AvatarDTO avatar)
        {
            var response = await _httpClient.PostAsJsonAsync("CreateAvatar", avatar);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAvatarAsync(int id, AvatarDTO avatar)
        {
            var response = await _httpClient.PutAsJsonAsync($"UpdateAvatar/{id}", avatar);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAvatarAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteAvatar/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<AvatarDTO> GetAvatarByUserId(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"GetAvatarByUserId/{userId}");

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<AvatarDTO>(response.Content.ReadAsStringAsync().Result);
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
