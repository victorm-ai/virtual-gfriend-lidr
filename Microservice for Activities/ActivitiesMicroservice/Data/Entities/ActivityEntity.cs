namespace ActivitiesMicroservice.Data.Entities
{
    public class ActivityEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime WhenIs { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
