using VirtualGirlfriendFrontend.Models.DTOs;

namespace VirtualGirlfriendFrontend.Services.Interfaces
{
    public interface IUserApiClient
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserAsync(int id);
        Task<bool> CreateUserAsync(UserDTO user);
        Task<bool> UpdateUserAsync(int id, UserDTO user);
        Task<bool> DeleteUserAsync(int id);
        Task<UserDTO> LoginAsync(string email, string password);
    }
}
