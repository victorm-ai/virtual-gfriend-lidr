using VirtualGirlfriendFrontend.Models.DTOs;
using VirtualGirlfriendFrontend.Services.Interfaces;

namespace VirtualGirlfriendFrontend.Services.Classes
{
    public class MessageApiClient : IMessageApiClient
    {
        private readonly HttpClient _httpClient;

        public MessageApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // POST: SendMessage
        public async Task<bool> SendMessageAsync(MessageDTO message)
        {
            var response = await _httpClient.PostAsJsonAsync("SendMessage", message);
            return response.IsSuccessStatusCode;
        }
    }
}
