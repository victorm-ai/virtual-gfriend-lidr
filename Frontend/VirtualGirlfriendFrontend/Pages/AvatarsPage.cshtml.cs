using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using VirtualGirlfriendFrontend.Models.DTOs;
using VirtualGirlfriendFrontend.Services.Interfaces;

namespace VirtualGirlfriendFrontend.Pages
{
    public class AvatarsPageModel : PageModel
    {
        private readonly IAvatarApiClient _AvatarService;

        public AvatarsPageModel(IAvatarApiClient avatarService)
        {
            _AvatarService = avatarService;
        }

        [BindProperty]
        public AvatarDTO NewAvatar { get; set; }

        public UserDTO LoguedUser { get; set; }

        // Lista de personalidades para el combo box
        public List<(int Id, string Name)> PersonalityOptions { get; set; }

        public async Task OnGet()
        {
            LoguedUser = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("LoginUser"));

            var result = await _AvatarService.GetAvatarByUserId(LoguedUser.Id);

            if (result != null)
            {
                NewAvatar = result;
            }

            else 
            {
                NewAvatar = new AvatarDTO() { PersonalityId = 1 };
            } 

            
            PersonalityOptions = new List<(int, string)>
            {
                (1, "Brave"),
                (2, "Clever"),
                (3, "Kind"),
                (4, "Funny")
            };
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            if (ModelState.IsValid)
            {
                LoguedUser = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("LoginUser"));
                NewAvatar.UserId = LoguedUser.Id;

                var result = await _AvatarService.UpdateAvatarAsync(NewAvatar.Id, NewAvatar);

                if (result)
                {
                    TempData["MessageResult"] = "The avatar was updated succesfully!";
                    return RedirectToPage("CompletedAction");
                }
            }

            return Page();
        }

        public async Task <IActionResult> OnPostDelete()
        {
            if (ModelState.IsValid)
            {


                var result = await _AvatarService.DeleteAvatarAsync(NewAvatar.Id);

                if (result)
                {
                    TempData["MessageResult"] = "The account was deleted succesfully!";
                    return RedirectToPage("CompletedAction");
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCreate()
        {
            if (ModelState.IsValid)
            {
                LoguedUser = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("LoginUser"));
                NewAvatar.UserId = LoguedUser.Id;

                var result = await _AvatarService.CreateAvatarAsync(NewAvatar);

                if (result)
                {
                    TempData["MessageResult"] = "The avatar was created succesfully!";
                    return RedirectToPage("CompletedAction");
                }
            }

            return Page();
        }

        public void OnChat()
        {
            RedirectToPage("ChatInteraction");           
        }
    }
}
