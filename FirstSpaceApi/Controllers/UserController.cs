using FirstSpaceApi.Shared.Database.IRepository;
using FirstSpaceApi.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstSpaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllUserAsync()
        {
            var allUsers =  _userRepository.GetUserDetails();
            if (allUsers == null)
            {
                return NotFound(); // No users found
            }

            return Ok(allUsers);
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] User user)
        {
            var addedUser = _userRepository.AddUser(user);
            if (addedUser == null)
            {
                return NotFound(); // No users found
            }

            return Ok(addedUser);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserByID(string userId)
        {
            var addedUser = _userRepository.GetUserDetailById(userId);
            if (addedUser == null)
            {
                return NotFound(); // No users found
            }

            return Ok(addedUser);
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            var updatedUser = _userRepository.UpdateUser(user);
            if (updatedUser == null)
            {
                return NotFound(); // No users found
            }

            return Ok(updatedUser);
        }

        [HttpDelete("Remove/{userId}")]
        public IActionResult RemoveUserById(string userId)
        {
            var deletedUser = _userRepository.DeleteUser(userId);
            if (deletedUser == null)
            {
                return NotFound(); // No users found
            }

            return Ok(deletedUser);
        }


    }
}
