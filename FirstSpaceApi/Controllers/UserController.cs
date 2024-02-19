using FirstSpaceApi.Shared.Database.IRepository;
using FirstSpaceApi.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static FirstSpaceApi.Shared.DTO.Dto;
using static FirstSpaceApi.Shared.ViewModels.ViewModel;
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
        public async Task<IActionResult> GetAllUserAsync([FromQuery] UserPagingVM userPagingVM)
        {
            try
            {
                var pagedResult = await _serviceProvider.UserService.GetAllUser(userPagingVM, trackChanges: false);
                
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

                return Ok(pagedResult.users);
            }
            catch
            {
                return StatusCode(500, "Internal server error");

            }
        }   


        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestVM user)
        {
            if (user == null)
            {
                return BadRequest("user object is null")    ;
            }

            var userResponseVM = await _serviceProvider.UserService.CreateUser(user);

            //return CreatedAtRoute("GetUserByID", new { id = userResponseVM.UserId }, userResponseVM);
            return Ok(userResponseVM);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByID(Guid userId)
        {
            var users = await _serviceProvider.UserService.GetUserByID(userId, trackChanges: false);
            if (users == null)
            {
                return NotFound(); // No users found
            }

            return Ok(users);
        }

        [HttpPut("UpdateUser/{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UserRequestVM user)
        {
            await _serviceProvider.UserService.UpdateUser(userId, user, false);

            return NoContent();
        }

        [HttpDelete("Remove/{userId}")]
        public async Task<IActionResult> RemoveUserById(Guid userId)
        {
            await _serviceProvider.UserService.DeleteUser(userId, false);
           
            return NoContent();
        }

    }
}
