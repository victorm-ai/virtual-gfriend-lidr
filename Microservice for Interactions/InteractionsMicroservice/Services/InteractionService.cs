using InteractionsMicroservice.DTOs;
using InteractionsMicroservice.Interfaces;
using InteractionsMicroservice.Models;

namespace InteractionsMicroservice.Services
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionRepository _InteractionRepository;

        public InteractionService(IInteractionRepository userRepository) 
        {
            _InteractionRepository = userRepository;
        }
      
        public IEnumerable<InteractionDTO> GetInteractions(int userId, DateTime dateTime)
        {
            return _InteractionRepository.GetInteractions(userId, dateTime);
        }

        public IEnumerable<InteractionDTO> GetInteractions(int userId, int interactionType, DateTime dateTime)
        {
            return _InteractionRepository.GetInteractions(userId, interactionType, dateTime);
        }

        public void SaveUserInteraction(InteractionDTO interaction)
        {
            _InteractionRepository.SaveUserInteraction(interaction);
        }
    }
}
