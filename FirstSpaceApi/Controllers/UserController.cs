using FirstSpaceApi.Shared.Database.IRepository;
using FirstSpaceApi.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static FirstSpaceApi.Shared.DTO.Dto;
using FSServiceProvider = FirstSpaceApi.Services.IService;

namespace FirstSpaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private FSServiceProvider.IServiceProvider _serviceProvider;

        public UserController(FSServiceProvider.IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public IActionResult GetAllUserAsync()
        {
            try
            {
                var users = _serviceProvider.UserService.GetAllUser(trackChanges: false);
                return Ok(users);
            }
            catch
            {
                return StatusCode(500, "Internal server error");

            }
        }


        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserRequestVM user)
        {
            if (user == null)
            {
                return BadRequest("user object is null")    ;
            }

            var userResponseVM = _serviceProvider.UserService.CreateUser(user);

            //return CreatedAtRoute("GetUserByID", new { id = userResponseVM.UserId }, userResponseVM);
            return Ok(userResponseVM);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserByID(Guid userId)
        {
            var users = _serviceProvider.UserService.GetUserByID(userId, trackChanges: false);
            if (users == null)
            {
                return NotFound(); // No users found
            }

            return Ok(users);
        }

        [HttpPut("UpdateUser/{userId}")]
        public IActionResult UpdateUser(Guid userId, [FromBody] UserRequestVM user)
        {
            _serviceProvider.UserService.UpdateUser(userId, user, false);

            return NoContent();
        }

        [HttpDelete("Remove/{userId}")]
        public IActionResult RemoveUserById(Guid userId)
        {
            _serviceProvider.UserService.DeleteUser(userId, false);
           
            return NoContent();
        }

    }
}
