using billboard.Model;
using billboard.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet(Name = "GetAllUsers")]
        public Task<IEnumerable<Model.User>> GetAllUsersAsync()
        {
            return userService.GetAllUsersAsync();
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<Model.User>> GetUserByIdAsync(int id)
        {
            var user = await userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost(Name = "CreateUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreateUserAsync(Model.User user)
        {
            await userService.CreateUserAsync(user);
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Model.User user)
        {
            if (id != user.IdUser)
                return BadRequest();

            await userService.UpdateUserAsync(user);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // Current user by Id
            var existingUser = await GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            await userService.DeleteUserAsync(id);

            return NoContent();
        }
    }
}
