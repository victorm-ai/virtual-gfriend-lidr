using Microsoft.AspNetCore.Mvc;
using AchievementsMicroservice.DTOs;
using AchievementsMicroservice.Interfaces;
using AchievementsMicroservice.Models;
using AchievementsMicroservice.Services;

namespace AchievementsMicroservice.Controllers
{
    [ApiController]
    [Route("api/achievements")]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementService _AchievementService;

        public AchievementController(IAchievementService achievementService)
        {
            _AchievementService = achievementService;
        }

        [HttpGet("GetAchievements")]
        public IActionResult GetAchievements()
        {
            try
            {
                var result = _AchievementService.GetAchievements();

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


        [HttpGet("GetAchievements/{userId}")]
        public IActionResult GetAchievements(int userId)
        {
            try
            {
                var result = _AchievementService.GetAchievements(userId);

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

        [HttpPost("SaveAchievement/{userId}/{achievementId}")]
        public IActionResult SaveAchievement(int userId, int achievementId) 
        {
            try
            {
                _AchievementService.SaveAchievement(userId, achievementId);

                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
       
        }          
    }
}
