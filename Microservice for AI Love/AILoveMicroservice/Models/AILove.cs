namespace AILoveMicroservice.Models
{
    public class AILove
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}
