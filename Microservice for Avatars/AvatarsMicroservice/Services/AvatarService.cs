using AvatarsMicroservice.DTOs;
using AvatarsMicroservice.Interfaces;
using AvatarsMicroservice.Models;

namespace AvatarsMicroservice.Services
{
    public class AvatarService : IAvatarService
    {
        private readonly IAvatarRepository _AvatarRepository;

        public AvatarService(IAvatarRepository avatarRepository) 
        {
            _AvatarRepository = avatarRepository;
        }

        public IEnumerable<AvatarDTO> GetAvatars()
        {
            return _AvatarRepository.GetAvatars();
        }

        public AvatarDTO GetAvatar(int userId)
        {
            return _AvatarRepository.GetAvatar(userId);
        }

        public void CreateAvatar(AvatarDTO avatar)
        {
            _AvatarRepository.CreateAvatar(avatar);
        }

        public void UpdateAvatar(int userId, AvatarDTO avatar)
        {
            _AvatarRepository.UpdateAvatar(userId, avatar);
        }

        public void DeleteAvatar(int avatarId)
        {
            _AvatarRepository.DeleteAvatar(avatarId);
        }

        public AvatarDTO GetAvatarByUserId(int userId)
        {
            return _AvatarRepository.GetAvatarByUserId(userId);
        }
    }
}
