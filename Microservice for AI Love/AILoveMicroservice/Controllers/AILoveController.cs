using Microsoft.AspNetCore.Mvc;
using AILoveMicroservice.DTOs;
using AILoveMicroservice.Interfaces;
using AILoveMicroservice.Models;
using AILoveMicroservice.Services;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace AILoveMicroservice.Controllers
{
    [ApiController]
    [Route("api/ailove")]
    public class AILoveController : ControllerBase
    {
        private readonly IAILoveService _AILoveService;
        public AILoveController(IAILoveService _aILoveService)
        {
            _AILoveService = _aILoveService;
        }

        [HttpPost("SendMessage")]
        public IActionResult SendMessage([FromBody] string interactionRequest)

        //public IActionResult SendMessage([FromBody] InteractionDTO interactionRequest) 
        {
            try
            {
                var interaction=JsonConvert.DeserializeObject<InteractionDTO>(interactionRequest);
                
                var result = _AILoveService.SendMessage(interaction);

                if (result != null)
                { 
                    return Ok(result);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
       
        }          
    }
}
