using VirtualGirlfriendFrontend.Models.DTOs;

namespace VirtualGirlfriendFrontend.Services.Interfaces
{
    public interface IMessageApiClient
    {
        Task<bool> SendMessageAsync(MessageDTO message);
    }
}
