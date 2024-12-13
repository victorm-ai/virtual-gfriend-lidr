namespace VirtualGirlfriendFrontend.Models.DTOs
{
    public class InteractionDTO
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public int AvatarId { get; set; }
        public string ContentInteraction { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
