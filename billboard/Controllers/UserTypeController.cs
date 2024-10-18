using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService userTypeService;
        public UserTypeController(IUserTypeService _userTypeService)
        {
            userTypeService = _userTypeService;
        }

        [HttpGet(Name = "GetAllUserTypes")]
        public Task<IEnumerable<Model.UserType>> GetAllUserTypesAsync()
        {
            return userTypeService.GetAllUserTypesAsync();
        }

        [HttpGet("{id}", Name = "GetUserTypeById")]
        public async Task<ActionResult<Model.UserType>> GetUserTypeByIdAsync(int id)
        {
            var usertype = await userTypeService.GetUserTypeByIdAsync(id);
            if (usertype == null)
                return NotFound();

            return Ok(usertype);
        }

        [HttpPost(Name = "CreateUserType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreateUserTypeAsync(Model.UserType usertype)
        {
            await userTypeService.CreateUserTypeAsync(usertype);
        }

        [HttpPut("{id}", Name = "UpdateUserType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserType(int id, [FromBody] Model.UserType usertype)
        {
            if (id != usertype.Id_Usertype)
                return BadRequest();

            await userTypeService.UpdateUserTypeAsync(usertype);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteUserType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUserType(int id)
        {
            // Current UserType by Id
            var existingUserType = await GetUserTypeByIdAsync(id);
            if (existingUserType == null)
                return NotFound();

            await userTypeService.DeleteUserTypeAsync(id);

            return NoContent();
        }
    }
}
