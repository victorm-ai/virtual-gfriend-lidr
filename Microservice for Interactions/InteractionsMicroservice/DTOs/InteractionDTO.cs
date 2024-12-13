namespace InteractionsMicroservice.DTOs
{
    public class InteractionDTO
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public int AvatarId { get; set; }
        public int InteractionTypeId { get; set; }
        public string ContentInteraction {  get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
