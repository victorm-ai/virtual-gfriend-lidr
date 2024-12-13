﻿using InteractionsMicroservice.DTOs;
using InteractionsMicroservice.Models;

namespace InteractionsMicroservice.Interfaces
{
    public interface IInteractionService
    {
        public IEnumerable<InteractionDTO> GetInteractions(int userId, DateTime dateTime);
        public IEnumerable<InteractionDTO> GetInteractions(int userId, int interactionType, DateTime dateTime);
        public void SaveUserInteraction(InteractionDTO interaction);
    }
}
