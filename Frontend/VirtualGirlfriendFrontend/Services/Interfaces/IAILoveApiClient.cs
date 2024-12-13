using VirtualGirlfriendFrontend.Models.DTOs;

namespace VirtualGirlfriendFrontend.Services.Interfaces
{
    public interface IAILoveApiClient
    {
        public Task<string> SendMessage(InteractionDTO interaction);
    }
}
