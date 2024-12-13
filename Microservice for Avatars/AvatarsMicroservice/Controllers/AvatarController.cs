using Microsoft.AspNetCore.Mvc;
using AvatarsMicroservice.DTOs;
using AvatarsMicroservice.Interfaces;
using AvatarsMicroservice.Models;
using AvatarsMicroservice.Services;

namespace AvatarsMicroservice.Controllers
{
    [ApiController]
    [Route("api/avatars")]
    public class AvatarController : ControllerBase
    {
        private readonly IAvatarService _AvatarService;

        public AvatarController(IAvatarService avatarService)
        {
            _AvatarService = avatarService;
        }

        [HttpGet("GetAvatars")]
        public IActionResult GetAvatars()
        {
            try
            {
                var result = _AvatarService.GetAvatars();

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


        [HttpGet("GetAvatar/{avatarId}")]
        public IActionResult GetAvatar(int avatarId)
        {
            try
            {
                var result = _AvatarService.GetAvatar(avatarId);

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


        [HttpGet("GetAvatarByUserId/{userId}")]
        public IActionResult GetAvatarByUserId(int userId)
        {
            try
            {
                var result = _AvatarService.GetAvatarByUserId(userId);

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


        [HttpPost("CreateAvatar")]
        public IActionResult CreateAvatar([FromBody] AvatarDTO CreateAvatarRequest) 
        {
            try
            {
                _AvatarService.CreateAvatar(CreateAvatarRequest);

                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
       
        }


        [HttpPut("UpdateAvatar")]
        public IActionResult UpdateAvatar(int userId, [FromBody] AvatarDTO UpdateAvatarRequest)
        {
            try
            {
                _AvatarService.UpdateAvatar(userId, UpdateAvatarRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


        [HttpDelete("DeleteAvatar/{avatarId}")]
        public IActionResult DeleteAvatar(int avatarId)
        {
            try
            {
                _AvatarService.DeleteAvatar(avatarId);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
