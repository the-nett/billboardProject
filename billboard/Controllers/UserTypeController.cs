using AutoMapper;
using billboard.Model;
using billboard.Model.Dtos.UserTypes;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService userTypeService;
        private readonly IMapper mapper;
        public UserTypeController(IUserTypeService _userTypeService, IMapper _mapper)
        {
            userTypeService = _userTypeService;
            mapper = _mapper;
        }

        [HttpGet(Name = "GetAllUserTypes")]
        public async Task<IActionResult> GetUserTypeAsync()
        {
            var listUserTypes = await userTypeService.GetAllUserTypesAsync();
            var listaPermissionsDto = new List<UserTypeDto>();

            foreach (var usertype in listUserTypes)
            {
                listaPermissionsDto.Add(mapper.Map<UserTypeDto>(usertype));
            }

            return Ok(listaPermissionsDto);
        }

        [HttpGet("{id}", Name = "GetUserTypeById")]
        public async Task<IActionResult> GetUserTypeIdAsync(int id)
        {
            var usertype = await userTypeService.GetUserTypeByIdAsync(id);
            if (usertype == null)
                return NotFound();

            var user = mapper.Map<UserTypeDto>(usertype);
            return Ok(user);
        }

        [HttpPost(Name = "CreateUserType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateUserType([FromBody] CreateUserTypeDto createUserTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user_type = mapper.Map<UserType>(createUserTypeDto);
            var createdUsertype = await userTypeService.CreateUserTypeAsync(user_type);
            return Ok(user_type);
        }


        [HttpPut("{id}", Name = "UpdateUserType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserType(int id, [FromBody] UserTypeDto userTypeDto)
        {
            if (id != userTypeDto.Id_Usertype)
                return BadRequest();

            var usertype = mapper.Map<UserType>(userTypeDto);

            var updateusertype = await userTypeService.UpdateUserTypeAsync(usertype);

            return Ok(usertype);
        }

        [HttpDelete("{id}", Name = "DeleteUserType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUserType(int id)
        {
            // Current UserType by Id
            var existingUserType = await GetUserTypeIdAsync(id);
            if (existingUserType == null)
                return NotFound();

            await userTypeService.DeleteUserTypeAsync(id);

            return NoContent();
        }
    }
}
