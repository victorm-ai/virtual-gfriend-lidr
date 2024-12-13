using UsersMicroservice.Data.Entities;
using UsersMicroservice.DTOs;
using UsersMicroservice.Models;

namespace UsersMicroservice.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<UserDTO> GetUsers();
        public UserDTO GetUser(int userId);
        public void CreateUser(UserDTO user);
        public void UpdateUser(int userId, UserDTO user);
        public void DeleteUser(int userId);
        public UserDTO Login(string email, string password);
    }
}
