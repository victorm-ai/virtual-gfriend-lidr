namespace ActivitiesMicroservice.DTOs
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }     
        public string Name { get; set; }
        public DateTime WhenIs { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
