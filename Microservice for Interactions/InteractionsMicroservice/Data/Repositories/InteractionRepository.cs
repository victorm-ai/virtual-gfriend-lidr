using InteractionsMicroservice.Data.Entities;
using InteractionsMicroservice.DTOs;
using InteractionsMicroservice.Interfaces;
using InteractionsMicroservice.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.VisualBasic;
using System.Collections.Concurrent;

namespace InteractionsMicroservice.Data.Repositories
{
    public class InteractionRepository : IInteractionRepository
    {
        private readonly InteractionsDbContext _InteractionDbContext;

        public InteractionRepository()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                          .Build();

            _InteractionDbContext = new InteractionsDbContext(configuration);
        }

        public IEnumerable<InteractionDTO> GetInteractions(int userId, DateTime dateTime)
        {
            try
            {
                var result = _InteractionDbContext.Interactions.Where(i => i.UserId == userId && i.Timestamp == dateTime).ToList();

                if (result != null && result.Count()>0)
                {
                    var interactionsList = new List<InteractionDTO>();

                    result.ForEach(i => interactionsList.Add(new InteractionDTO()
                    {
                        AvatarId = i.AvatarId,
                        ContentInteraction = i.ContentInteraction,
                        InteractionTypeId = i.InteractionTypeId,
                        Timestamp = DateTimeOffset.UtcNow,
                        UserId = userId,
                    }));

                    return interactionsList;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<InteractionDTO> GetInteractions(int userId, int interactionTypeId, DateTime dateTime)
        {
            try
            {
                var result = _InteractionDbContext.Interactions.Where(i => i.UserId == userId && 
                                                                      i.Timestamp == dateTime && 
                                                                      i.InteractionTypeId == interactionTypeId).ToList();

                if (result != null && result.Count>0)
                {
                    var interactionsList = new List<InteractionDTO>();

                    result.ForEach(i => interactionsList.Add(new InteractionDTO()
                    {
                        AvatarId = i.AvatarId,
                        ContentInteraction = i.ContentInteraction,
                        InteractionTypeId = i.InteractionTypeId,
                        Timestamp = DateTimeOffset.UtcNow,
                        UserId = userId,
                    }));

                    return interactionsList;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveUserInteraction(InteractionDTO interaction)
        {
            try
            {
                var newInteraction = new InteractionEntity()
                {
                    AvatarId = interaction.AvatarId,
                    InteractionTypeId = interaction.InteractionTypeId,
                    UserId = interaction.UserId,
                    Timestamp = DateTime.UtcNow,
                    ContentInteraction = interaction.ContentInteraction,
                };

                _InteractionDbContext.Interactions.Add(newInteraction);
                _InteractionDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

      

      
       
    }
}
