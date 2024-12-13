namespace AILoveMicroservice.Data.Entities
{
    public class AILoveEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public bool IsActive { get; set; }
    }
}
