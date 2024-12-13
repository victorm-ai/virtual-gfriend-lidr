using UsersMicroservice.DTOs;
using UsersMicroservice.Interfaces;
using UsersMicroservice.Models;

namespace UsersMicroservice.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository userRepository) 
        {
            _UserRepository = userRepository;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return _UserRepository.GetUsers();
        }

        public UserDTO GetUser(int userId)
        {
            return _UserRepository.GetUser(userId);
        }

        public void CreateUser(UserDTO user)
        {
            _UserRepository.CreateUser(user);
        }

        public void UpdateUser(int userId, UserDTO user)
        {
            _UserRepository.UpdateUser(userId, user);
        }

        public void DeleteUser(int userId)
        {
            _UserRepository.DeleteUser(userId);
        }

        public UserDTO Login(string email, string password)
        {
            return _UserRepository.Login(email, password);
        }
    }
}
