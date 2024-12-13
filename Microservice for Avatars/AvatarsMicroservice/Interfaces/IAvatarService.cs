using AvatarsMicroservice.DTOs;
using AvatarsMicroservice.Models;

namespace AvatarsMicroservice.Interfaces
{
    public interface IAvatarService
    {
        public IEnumerable<AvatarDTO> GetAvatars();
        public AvatarDTO GetAvatar(int userId);
        public void CreateAvatar(AvatarDTO avatar);        
        public void UpdateAvatar(int userId, AvatarDTO avatar);
        public void DeleteAvatar(int avatarId);
        public AvatarDTO GetAvatarByUserId(int userId);
    }
}
