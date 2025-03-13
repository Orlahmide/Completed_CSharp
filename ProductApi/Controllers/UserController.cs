using BusinessLogic.Services;
using DomainLayer.DataTransferObject;
using DomainLayer.Models;
using DomainLayer.NewFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/user-management")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Create users.
        /// </summary>
        [HttpPost("create-user")]

        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto, Role role)
        {
            if (createUserDto == null)
                return BadRequest("Invalid user data.");

            var updatedUser = _userService.AddUser(createUserDto, role);
            if (updatedUser == null)
                return NotFound(new { message = "User not found." });

            return Ok(updatedUser);
        }

        /// <summary>
        /// User login with email and password.
        /// </summary>
        [HttpPost("auth/login")]
        public IActionResult UserLogin([FromBody] LoginDto loginDto)
        {
            var token = _userService.Login(loginDto);
            if (token == null)
                return Unauthorized(new { message = "Invalid email or password." });

            return Ok(new { token });
        }

        /// <summary>
        /// Get details of a specific user by ID.
        /// </summary>
        [HttpGet("profile/{userId}")]
        [Authorize]
        public ActionResult<User> FetchUserById(int userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
                return NotFound(new { message = "User not found." });

            return Ok(user);
        }

        [HttpGet("allProfile")]
        [Authorize]
        public ActionResult<User> FetchAllUser()
        {
            var users = _userService.GetAllUsers();
            if (users == null)
                return NotFound(new { message = "Users not found." });

            return Ok(users);
        }


        /// <summary>
        /// Update user details.
        /// </summary>
        [HttpPut("update-profile")]
        [Authorize]
        public IActionResult UpdateUserProfile([FromBody] UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null)
                return BadRequest("Invalid user data.");

            var updatedUser = _userService.UpdateUser(updateUserDto);
            if (updatedUser == null)
                return NotFound(new { message = "User not found." });

            return Ok(updatedUser);
        }

        /// <summary>
        /// Remove a user account.
        /// </summary>
        [HttpDelete("delete/{userId}")]
        [Authorize]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
