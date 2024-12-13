namespace UsersMicroservice.Data.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public bool IsActive { get; set; }
        public string Account {  get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
    }
}
