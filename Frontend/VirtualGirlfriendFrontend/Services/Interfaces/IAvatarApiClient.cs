using VirtualGirlfriendFrontend.Models.DTOs;

namespace VirtualGirlfriendFrontend.Services.Interfaces
{
    public interface IAvatarApiClient
    {
        public Task<IEnumerable<AvatarDTO>> GetAvatarsAsync();
        public Task<AvatarDTO> GetAvatarAsync(int id);
        public Task<bool> CreateAvatarAsync(AvatarDTO avatar);
        public Task<bool> UpdateAvatarAsync(int id, AvatarDTO avatar);
        public Task<bool> DeleteAvatarAsync(int id);
        public Task<AvatarDTO> GetAvatarByUserId(int userId);      
    }
}
