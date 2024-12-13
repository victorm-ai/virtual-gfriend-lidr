namespace AvatarsMicroservice.Models
{
    public class AvatarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int PersonalityId { get; set; }
        public TimeSpan Timespan { get; set; }
    }
}
