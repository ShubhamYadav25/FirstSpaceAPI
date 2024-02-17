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

        //[HttpPut("UpdateUser")]
        //public IActionResult UpdateUser([FromBody] User user)
        //{
        //    var updatedUser = _userRepository.UpdateUser(user);
        //    if (updatedUser == null)
        //    {
        //        return NotFound(); // No users found
        //    }

        //    return Ok(updatedUser);
        //}

        //[HttpDelete("Remove/{userId}")]
        //public IActionResult RemoveUserById(string userId)
        //{
        //    var deletedUser = _userRepository.DeleteUser(userId);
        //    if (deletedUser == null)
        //    {
        //        return NotFound(); // No users found
        //    }

        //    return Ok(deletedUser);
        //}


    }
}
