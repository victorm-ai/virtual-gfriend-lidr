using Microsoft.AspNetCore.Mvc;
using InteractionsMicroservice.DTOs;
using InteractionsMicroservice.Interfaces;
using InteractionsMicroservice.Models;
using InteractionsMicroservice.Services;

namespace InteractionsMicroservice.Controllers
{
    [ApiController]
    [Route("api/interactions")]
    public class InteractionController : ControllerBase
    {
        private readonly IInteractionService _InteractionService;

        public InteractionController(IInteractionService interactionService)
        {
            _InteractionService = interactionService;
        }

        [HttpGet("GetInteractions/{userId}/{date}")]
        public IActionResult GetInteractions(int userId, DateTime dateTime)
        {
            try
            {
                var result = _InteractionService.GetInteractions(userId, dateTime);

                if (result == null)
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("GetInteractions/{userId}/{interactionTypeId}/{dateTime}")]
        public IActionResult GetUserById(int userId, int interactionTypeId, DateTime dateTime)
        {
            try
            {
                var result = _InteractionService.GetInteractions(userId, interactionTypeId, dateTime);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("SaveInteraction")]
        public IActionResult SaveUserInteraction([FromBody] InteractionDTO CreateInteractionRequest)
        {
            try
            {
                _InteractionService.SaveUserInteraction(CreateInteractionRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
