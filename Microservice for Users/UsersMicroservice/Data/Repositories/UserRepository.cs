using UsersMicroservice.Data.Entities;
using UsersMicroservice.DTOs;
using UsersMicroservice.Interfaces;
using UsersMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace UsersMicroservice.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _UsersDbContext;

        public UserRepository()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                          .Build();

            _UsersDbContext = new UsersDbContext(configuration);
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var usersList = new List<UserDTO>();

            try
            {
                var result = _UsersDbContext.Users.Where(u=> u.IsActive).ToList();

                if (result != null)
                {
                    result.ForEach(a => usersList.Add(new UserDTO
                    { 
                        Id = a.Id, 
                        Name = a.Name, 
                        IsActive = a.IsActive, 
                        Account = a.Account,
                        BirthDate = a.BirthDate,
                        Email = a.Email,
                        Password = a.Password,
                    }));

                    return usersList;
                }

                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserDTO GetUser(int userId)
        {
            try
            {
                var result = _UsersDbContext.Users.FirstOrDefault(a => a.Id == userId && a.IsActive);

                if (result != null)
                {
                    return  new UserDTO()
                    {
                        Password = result.Password,
                        IsActive = result.IsActive,
                        Email = result.Email,
                        BirthDate= result.BirthDate,
                        Account = result.Account,
                        Id = result.Id,
                        Name = result.Name,                              
                    };
                }

                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateUser(UserDTO user)
        {
            try
            {
                var newUser = new UserEntity()
                {
                    Name = user.Name,
                    IsActive = true,
                    Account= user.Account,
                    BirthDate= user.BirthDate,
                    Email = user.Email,
                    Password = user.Password,
                    Timestamp = DateTimeOffset.UtcNow
                };

                _UsersDbContext.Users.Add(newUser);
                _UsersDbContext.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateUser(int userId, UserDTO user)
        {
            try
            {
                var result = _UsersDbContext.Users.FirstOrDefault(u => u.Id == user.Id && u.IsActive);

                if (result != null)
                {
                    result.Account = user.Account;
                    result.IsActive = user.IsActive;
                    result.Email = user.Email;
                    result.Password = user.Password;
                    result.BirthDate = user.BirthDate;
                    result.Name = user.Name;

                    _UsersDbContext.Users.Update(result);
                    _UsersDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                var result = _UsersDbContext.Users.FirstOrDefault(u => u.Id == userId);

                if (result != null)
                {
                    result.IsActive = false;

                    _UsersDbContext.Users.Update(result);
                    _UsersDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserDTO Login(string email, string password)
        {
            try
            {
                var result = _UsersDbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

                if (result != null)
                {
                    return new UserDTO()
                    {
                        Password = result.Password,
                        IsActive = result.IsActive,
                        Email = result.Email,
                        BirthDate = result.BirthDate,
                        Account = result.Account,
                        Id = result.Id,
                        Name = result.Name,
                    };
                }

                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
