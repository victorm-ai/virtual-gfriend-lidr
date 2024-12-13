using Microsoft.AspNetCore.Mvc;
using ActivitiesMicroservice.DTOs;
using ActivitiesMicroservice.Interfaces;
using ActivitiesMicroservice.Models;
using ActivitiesMicroservice.Services;

namespace ActivitiesMicroservice.Controllers
{
    [ApiController]
    [Route("api/activities")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _IActivityService;

        public ActivityController(IActivityService _activityService)
        {
            _IActivityService = _activityService;
        }

        [HttpGet("GetActivities/{userId}")]
        public IActionResult GetActivities(int userId)
        {
            try
            {
                var result = _IActivityService.GetActivities(userId);

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

        [HttpPost("SaveActivity")]
        public IActionResult SaveActivity([FromBody] ActivityDTO CreateActivityRequest) 
        {
            try
            {
                _IActivityService.SaveActivity(CreateActivityRequest);

                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }       
        }          

        [HttpPut("UpdateActivity/{userId}/{activityId}")]
        public IActionResult UpdateActivity(int userId, int activityId, [FromBody] ActivityDTO UpdateActivityRequest)             
        {
            try
            {
                _IActivityService.UpdateActivity(userId, activityId, UpdateActivityRequest);

                return Ok("User updated succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpDelete("DeleteActivity/{userId}/{activityId}")]
        public IActionResult DeleteActivity(int userId, int activityId)
        {
            try
            {
                _IActivityService.DeleteActivity(userId, activityId);

                return Ok("User deleted succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
