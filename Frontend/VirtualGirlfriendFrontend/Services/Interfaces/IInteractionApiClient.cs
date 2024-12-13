using VirtualGirlfriendFrontend.Models.DTOs;

namespace VirtualGirlfriendFrontend.Services.Interfaces
{
    public interface IInteractionApiClient
    {
        Task<IEnumerable<InteractionDTO>> GetInteractionsAsync(int userId, DateTime date);
        Task<IEnumerable<InteractionDTO>> GetInteractionsAsync(int userId, int interactionTypeId, DateTime dateTime);
        Task<bool> SaveInteractionAsync(InteractionDTO interaction);
    }
}
