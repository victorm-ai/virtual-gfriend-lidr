using AILoveMicroservice.DTOs;
using AILoveMicroservice.Interfaces;
using AILoveMicroservice.Models;

namespace AILoveMicroservice.Services
{
    public class AILoveService : IAILoveService
    {
        private readonly IAILoveRepository _AILoveRepository;

        public AILoveService(IAILoveRepository userRepository) 
        {
            _AILoveRepository = userRepository;
        }

        public string SendMessage(InteractionDTO interaction)
        {
            return _AILoveRepository.SendMessage(interaction);
        }


    }
}
