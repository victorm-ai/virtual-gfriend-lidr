using VirtualGirlfriendFrontend.Models.DTOs;
using VirtualGirlfriendFrontend.Services.Interfaces;

namespace VirtualGirlfriendFrontend.Services.Classes
{
    public class InteractionApiClient : IInteractionApiClient
    {
        private readonly HttpClient _httpClient;

        public InteractionApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: GetInteractions/{userId}/{date}
        public async Task<IEnumerable<InteractionDTO>> GetInteractionsAsync(int userId, DateTime date)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<InteractionDTO>>($"GetInteractions/{userId}/{date:yyyy-MM-ddTHH:mm:ss}");
        }

        // GET: GetInteractions/{userId}/{interactionTypeId}/{dateTime}
        public async Task<IEnumerable<InteractionDTO>> GetInteractionsAsync(int userId, int interactionTypeId, DateTime dateTime)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<InteractionDTO>>($"GetInteractions/{userId}/{interactionTypeId}/{dateTime:yyyy-MM-ddTHH:mm:ss}");
        }

        // POST: SaveInteraction
        public async Task<bool> SaveInteractionAsync(InteractionDTO interaction)
        {
            var response = await _httpClient.PostAsJsonAsync("SaveInteraction", interaction);
            return response.IsSuccessStatusCode;
        }
    }
}
