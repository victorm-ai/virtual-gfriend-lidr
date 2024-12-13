using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VirtualGirlfriendFrontend.Models.DTOs;
using VirtualGirlfriendFrontend.Services.Interfaces;

namespace VirtualGirlfriendFrontend.Pages
{
    public class SignInModel : PageModel
    {
        private readonly IUserApiClient _UserService;

        public SignInModel(IUserApiClient _userService)
        { 
            _UserService = _userService;
        }

        [BindProperty]
        public UserDTO NewUser { get; set; }

        public void OnGet()
        {
            // Aquí puedes inicializar valores predeterminados si es necesario.
            NewUser = new UserDTO
            {
                BirthDate = DateTime.Today
            };
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _UserService.CreateUserAsync(NewUser);

                if (result)
                {
                    TempData["MessageResult"] = "Your account was created, please go to login page and access!";
                    return RedirectToPage("SuccessSignIn");
                }
            }
            return Page();
        }
    }
}
