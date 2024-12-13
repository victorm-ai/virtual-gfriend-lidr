using AvatarsMicroservice.Data.Entities;
using AvatarsMicroservice.DTOs;
using AvatarsMicroservice.Interfaces;
using AvatarsMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace AvatarsMicroservice.Data.Repositories
{
    public class AvatarRepository : IAvatarRepository
    {
        private readonly AvatarsDbContext _AvatarsDbContext;

        public AvatarRepository()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                          .Build();

            _AvatarsDbContext = new AvatarsDbContext(configuration);
        }

        public IEnumerable<AvatarDTO> GetAvatars()
        {
            var avatarsList = new List<AvatarDTO>();

            try
            {
                var result = _AvatarsDbContext.Avatars.Where(a=> a.IsActive).ToList();

                if (result != null)
                {
                    result.ForEach(a => avatarsList.Add(new AvatarDTO
                    { 
                        Id = a.Id, 
                        Name = a.Name, 
                        IsActive = a.IsActive, 
                        PersonalityId = a.PersonalityId,
                        PhysicalAppearance= a.PhysicalAppearance,
                        Timestamp = a.Timestamp,
                        UserId = a.UserId,
                    }));

                    return avatarsList;
                }

                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public AvatarDTO GetAvatar(int avatarId)
        {
            try
            {
                var result = _AvatarsDbContext.Avatars.FirstOrDefault(a => a.Id == avatarId && a.IsActive);

                if (result != null)
                {
                    return  new AvatarDTO()
                    {
                        IsActive = result.IsActive,
                        Name = result.Name,
                        PersonalityId = result.PersonalityId,
                        PhysicalAppearance = result.PhysicalAppearance,
                        Timestamp = result.Timestamp,
                        UserId = result.UserId,
                    };
                }

                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateAvatar(AvatarDTO avatar)
        {
            try
            {
                var newAvatar = new AvatarEntity()
                {
                    IsActive = true,
                    Name = avatar.Name,
                    PersonalityId= avatar.PersonalityId,
                    PhysicalAppearance = avatar.PhysicalAppearance,
                    Timestamp = DateTime.UtcNow,
                    UserId= avatar.UserId,
                };

                _AvatarsDbContext.Avatars.Add(newAvatar);
                _AvatarsDbContext.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateAvatar(int userId, AvatarDTO avatar)
        {
            try
            {
                var result = _AvatarsDbContext.Avatars.FirstOrDefault(a => a.Id == avatar.Id && a.UserId == userId && a.IsActive);

                if (result != null)
                {
                    result.IsActive = avatar.IsActive;
                    result.Name = avatar.Name;
                    result.PersonalityId = avatar.PersonalityId;
                    result.PhysicalAppearance = avatar.PhysicalAppearance;
                    result.Timestamp = DateTime.UtcNow;
                    result.UserId = userId;

                    _AvatarsDbContext.Avatars.Update(result);
                    _AvatarsDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteAvatar(int avatarId)
        {
            try
            {
                var result = _AvatarsDbContext.Avatars.FirstOrDefault(a => a.Id == avatarId);

                if (result != null)
                {
                    result.IsActive = false;

                    _AvatarsDbContext.Avatars.Remove(result);
                    _AvatarsDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AvatarDTO GetAvatarByUserId(int userId)
        {
            try
            {
                var result = _AvatarsDbContext.Avatars.FirstOrDefault(a => a.UserId == userId && a.IsActive);

                if (result != null)
                {
                    return new AvatarDTO()
                    {
                        IsActive = result.IsActive,
                        Name = result.Name,
                        PersonalityId = result.PersonalityId,
                        PhysicalAppearance = result.PhysicalAppearance,
                        Timestamp = result.Timestamp,
                        UserId = result.UserId,
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
