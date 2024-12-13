using AILoveMicroservice.DTOs;
using AILoveMicroservice.Models;

namespace AILoveMicroservice.Interfaces
{
    public interface IAILoveService
    {
        public string SendMessage(InteractionDTO interaction);
    }
}
