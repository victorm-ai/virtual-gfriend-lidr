namespace AchievementsMicroservice.Data.Entities
{
    public class UserAchievementsEntity
    {
        public int Id { get; set; }
        public int AchievementId { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
