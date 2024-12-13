using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VirtualGirlfriendFrontend.Models.DTOs;
using VirtualGirlfriendFrontend.Services.Interfaces;

namespace VirtualGirlfriendFrontend.Pages
{
    public class AchievementsPageModel : PageModel
    {
        private readonly IAchievementsApiClient _AchievementService;

        public AchievementsPageModel(IAchievementsApiClient achievementService)
        {
            _AchievementService = achievementService;
        }

        public List<AchievementDTO> Achievements { get; set; }

        public async Task OnGet()
        {
            var result =  await _AchievementService.GetAchievementsAsync();

            if (result != null) 
            {
                Achievements = result.ToList();
            }

            else
            {
                Achievements = new List<AchievementDTO>();
            }
        }
    }
}
