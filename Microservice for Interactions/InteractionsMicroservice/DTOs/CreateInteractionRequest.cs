﻿namespace InteractionsMicroservice.DTOs
{
    public class CreateInteractionRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AvatarId { get; set; }
        public int InteractionTypeId { get; set; }
        public string ContentInteraction { get; set; }
        public DateTimeOffset Timespan { get; set; }
    }
}
