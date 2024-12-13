namespace VirtualGirlfriendFrontend.Models.DTOs
{
    public class UserAchievementDTO
    {
        public int Id { get; set; } 
        public int AchievementId { get; set; }  
        public int UserId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
