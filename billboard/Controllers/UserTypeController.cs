using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService usertypeService;
        public UserTypeController(IUserTypeService _usertypeService)
        {
            usertypeService = _usertypeService;
        }

        [HttpGet(Name = "GetAllUserTypes")]
        public Task<IEnumerable<UserType>> GetAllUserTypesAsync()
        {
            return usertypeService.GetAllUserTypesAsync();
        }
        [HttpGet("{id}", Name = "GetUserTypeById")]
        public async Task<ActionResult<UserType>> GetUserTypeByIdAsync(int id)
        {
            var usertype = await usertypeService.GetUserTypeByIdAsync(id);
            if (usertype == null)
                return NotFound();

            return Ok(usertype);
        }

        [HttpPost(Name = "CreateUserType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreateUserTypeAsync(UserType usertype)
        {
            await usertypeService.CreateUserTypeAsync(usertype);
        }
        [HttpPut("{id}", Name = "UpdateUserType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserType(int id, [FromBody] UserType userType)
        {
            if (id != userType.Id_Usertype)
                return BadRequest();

            await usertypeService.UpdateUserTypeAsync(userType);
            return NoContent();
        }
    }
}
