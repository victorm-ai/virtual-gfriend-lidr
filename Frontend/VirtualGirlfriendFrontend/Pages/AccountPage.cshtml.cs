using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using VirtualGirlfriendFrontend.Models.DTOs;
using VirtualGirlfriendFrontend.Services.Interfaces;

namespace VirtualGirlfriendFrontend.Pages
{
    public class AccountPageModel : PageModel
    {
        private readonly IUserApiClient _UserService;

        public AccountPageModel(IUserApiClient userService)
        { 
            _UserService = userService;
        }

        public UserDTO LoguedUser { get; set; }

        [BindProperty]
        public UserDTO User{ get; set; }

        public string ErrorMessage { get; set; }

        public async Task OnGet()
        {
            LoguedUser = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("LoginUser"));

            var result = await _UserService.GetUserAsync(LoguedUser.Id);

            if (result != null)
            {
                User = result;
            }

        }

        public async Task<IActionResult> OnPostUpdate()
        {
            if (ModelState.IsValid)
            {
                LoguedUser = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("LoginUser"));

                try
                {
                    var result = await _UserService.UpdateUserAsync(LoguedUser.Id, User);

                    if (result)
                    {
                        TempData["MessageResult"] = "The account was updated succesfully!";
                        return RedirectToPage("CompletedAction");
                    }
                }
                catch (Exception)
                {
                    ErrorMessage = "Invalid user data, please check.";
                    throw;
                }              
            }

            return Page(); 
        }

        public async Task<IActionResult> OnPostDelete()
        {
            if (ModelState.IsValid)
            {
                LoguedUser = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("LoginUser"));

                try
                {
                    var result = await _UserService.DeleteUserAsync(LoguedUser.Id);

                    if (result)
                    {
                        TempData["MessageResult"] = "The account was deleted succesfully!";
                        return RedirectToPage("CompletedAction");
                    }

                    ErrorMessage = "Unable to delete the account.";
                }
                catch (Exception ex)
                {
                    throw;
                }
              
            }

            return Page();
        }       
    }
}
