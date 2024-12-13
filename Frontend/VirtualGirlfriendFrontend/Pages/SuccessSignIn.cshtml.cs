using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VirtualGirlfriendFrontend.Pages
{
    public class SuccessSignInModel : PageModel
    {
        public void OnGet()
        {
            var messageResult = TempData["MessageResult"] as string;

            if (!string.IsNullOrEmpty(messageResult))
            {
                ViewData["MessageResult"] = messageResult;
            }
        }
    }
}