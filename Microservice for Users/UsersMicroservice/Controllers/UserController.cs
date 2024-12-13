using Microsoft.AspNetCore.Mvc;
using UsersMicroservice.DTOs;
using UsersMicroservice.Interfaces;
using UsersMicroservice.Models;
using UsersMicroservice.Services;

namespace UsersMicroservice.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService userService)
        {
            _UserService = userService;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                var result = _UserService.GetUsers();

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


        [HttpGet("GetUser/{userId}")]
        public IActionResult GetUser(int userId)
        {
            try
            {
                var result = _UserService.GetUser(userId);

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


        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserDTO CreateUserRequest) 
        {
            try
            {
                _UserService.CreateUser(CreateUserRequest);

                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
       
        }


        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(int userId, [FromBody] UserDTO UpdateUserRequest)
        {
            try
            {
                _UserService.UpdateUser(userId, UpdateUserRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


        [HttpDelete("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                _UserService.DeleteUser(userId);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


        [HttpPost("Login")]
        public IActionResult Login(string email, string password)
        {
            try
            {
                var result = _UserService.Login(email, password);

                if (result != null)
                { 
                    return Ok(result);  
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
