
using System.Text;
using VirtualGirlfriendFrontend.Models.DTOs;
using VirtualGirlfriendFrontend.Services.Interfaces;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text.Json;

namespace VirtualGirlfriendFrontend.Services.Classes
{
    public class UserApiClient : IUserApiClient
    {
        private readonly HttpClient _httpClient;

        public UserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<UserDTO>>("GetUsers");
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public async Task<UserDTO> GetUserAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<UserDTO>($"GetUser/{id}");
            }
            catch (Exception)
            {

                throw;
            }         
        }

        public async Task<bool> CreateUserAsync(UserDTO user)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("CreateUser", user);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task<bool> UpdateUserAsync(int id, UserDTO user)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"UpdateUser/{id}", user);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw;
            }       
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"DeleteUser/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserDTO> LoginAsync(string email, string password)
        {
            var json = JsonConvert.SerializeObject(new UserDTO() { Email = email, Password = password });
            var jsonContent = JsonContent.Create(json);

            try
            {
                var response = await _httpClient.PostAsync("loginuser", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<UserDTO>(response.Content.ReadAsStringAsync().Result);
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
