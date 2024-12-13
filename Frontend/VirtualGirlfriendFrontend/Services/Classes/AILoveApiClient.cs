using Newtonsoft.Json;
using System.Net.Http;
using VirtualGirlfriendFrontend.Models.DTOs;
using VirtualGirlfriendFrontend.Services.Interfaces;

namespace VirtualGirlfriendFrontend.Services.Classes
{
    public class AILoveApiClient : IAILoveApiClient
    {
        private readonly HttpClient _httpClient;

        public AILoveApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SendMessage(InteractionDTO interaction)
        {
            var json = JsonConvert.SerializeObject(interaction);
            var jsonContent = JsonContent.Create(json);

            var response = await _httpClient.PostAsync("SendMessage", jsonContent);
            //var response = await _httpClient.PostAsJsonAsync("SendMessage", interaction);


            if (response.IsSuccessStatusCode)
            { 
                return response.Content.ReadAsStringAsync().Result;
            }

            return "My dear... there is a problem with the connection!";
        }
    }
}
