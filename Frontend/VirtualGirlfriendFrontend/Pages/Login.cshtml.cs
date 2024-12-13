using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VirtualGirlfriendFrontend.Services;
using VirtualGirlfriendFrontend.Services.Interfaces;
using Newtonsoft.Json;

namespace VirtualGirlfriendFrontend.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserApiClient _UserService;

        public LoginModel(IUserApiClient userService)
        {
            _UserService = userService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _UserService.LoginAsync(Email, Password);
                
                if (result!=null)
                {
                    HttpContext.Session.SetString("LoginUser", JsonConvert.SerializeObject(result));

                    return RedirectToPage("MainPage");
                }

                ErrorMessage = "Invalid email or password.";
            }

            return Page();
        }
    }

}
