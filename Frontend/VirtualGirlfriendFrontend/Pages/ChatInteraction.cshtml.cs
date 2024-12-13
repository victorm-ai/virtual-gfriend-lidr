using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using VirtualGirlfriendFrontend.Models.DTOs;
using VirtualGirlfriendFrontend.Services.Interfaces;

namespace VirtualGirlfriendFrontend.Pages
{
    public class ChatInteractionModel : PageModel
    {
        private readonly IAILoveApiClient _AILoveService;
        public UserDTO LoguedUser { get; set; }

        [BindProperty]
        public string UserMessage { get; set; }

        public string ConversationText { get; set; }

        public ChatInteractionModel(IAILoveApiClient aiLoveService)
        { 
            _AILoveService = aiLoveService;
        }

        public static List<string> Conversation = new List<string>();

        public void OnGet()
        {
            // Generar el texto a mostrar en el textarea
            var sb = new StringBuilder();

            foreach (var line in Conversation)
            {
                sb.AppendLine(line);
            }
            ConversationText = sb.ToString();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(UserMessage))
                {
                    Conversation.Add("You: " + UserMessage);
                    Conversation.Add("Girlfriend: " + await GetGirlfriendAnswer(UserMessage));
                }
            }

            return RedirectToPage();
        }

        private async Task<string> GetGirlfriendAnswer(string userMessage)
        {

            LoguedUser = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("LoginUser"));

            var interaction = new InteractionDTO()
            {
                ContentInteraction = userMessage,
                UserId = LoguedUser.Id,
            };

            var result = await _AILoveService.SendMessage(interaction);

            return result;
        }
    }
}
