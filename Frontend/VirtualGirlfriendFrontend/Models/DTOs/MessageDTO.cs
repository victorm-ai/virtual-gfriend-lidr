namespace VirtualGirlfriendFrontend.Models.DTOs
{
    public class MessageDTO
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}
