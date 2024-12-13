using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using VirtualGirlfriendFrontend.Models.DTOs;
using VirtualGirlfriendFrontend.Services.Interfaces;

namespace VirtualGirlfriendFrontend.Pages
{
    public class ActivitiesPageModel : PageModel
    {
        private readonly IActivityApiClient _ActivityService;

        public ActivitiesPageModel(IActivityApiClient activityService)
        {
            _ActivityService = activityService;
        }

        [BindProperty]
        public ActivityDTO NewActivity { get; set; }

        public UserDTO LoguedUser { get; set; }

        [BindProperty]
        public List<ActivityDTO> ActivitiesList { get; set; }

        public async Task OnGet()
        {
            LoguedUser = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("LoginUser"));

            var result = await _ActivityService.GetActivitiesAsync(LoguedUser.Id);

            if (result != null)
            {
                ActivitiesList = result.ToList();
                NewActivity = result.FirstOrDefault();
            }

            else
            {
                ActivitiesList = new List<ActivityDTO>();
                NewActivity = new ActivityDTO();
            }
        }

        public async Task <IActionResult> OnPostUpdate()
        {
            LoguedUser = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("LoginUser"));
            NewActivity.UserId = LoguedUser.Id;

            var result = await _ActivityService.UpdateActivityAsync(NewActivity.Id, NewActivity);

            if (result)
            {
                TempData["MessageResult"] = "The activity was updated succesfully!";
                return RedirectToPage("CompletedAction");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            LoguedUser = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("LoginUser"));
            NewActivity.UserId = LoguedUser.Id;

            var result = await _ActivityService.DeleteActivityAsync(NewActivity.UserId, NewActivity.Id);

            if (result)
            {
                TempData["MessageResult"] = "The activity was deleted succesfully!";
                return RedirectToPage("CompletedAction");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCreate()
        {
            LoguedUser = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("LoginUser"));
            NewActivity.UserId = LoguedUser.Id;

            var result = await _ActivityService.SaveActivityAsync(NewActivity);

            if (result)
            {
                TempData["MessageResult"] = "The activity was created succesfully!";
                return RedirectToPage("CompletedAction");
            }
        
            return Page();  
        }
    }
}
