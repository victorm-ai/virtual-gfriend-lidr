namespace AvatarsMicroservice.Data.Entities
{
    public class AvatarEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int PersonalityId { get; set; }
        public DateTimeOffset Timestamp{ get; set; }
        public bool IsActive { get; set; }
        public string PhysicalAppearance { get; set; }

    }
}
