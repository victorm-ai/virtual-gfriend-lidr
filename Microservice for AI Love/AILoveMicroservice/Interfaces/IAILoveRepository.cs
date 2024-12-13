using AILoveMicroservice.Data.Entities;
using AILoveMicroservice.DTOs;
using AILoveMicroservice.Models;

namespace AILoveMicroservice.Interfaces
{
    public interface IAILoveRepository
    {
        public string SendMessage(InteractionDTO interaction);
    }
}
