using AutoMapper;
using billboard.Model;
using billboard.Model.Dtos.Permissions;
using billboard.Model.Dtos.UserTypeXPermissions;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypePermissionsController : ControllerBase
    {
        private readonly IUserTypePermissionsService userTypePermissionsService;
        private readonly IMapper mapper;

        public UserTypePermissionsController(IUserTypePermissionsService userTypePermissionService, IMapper _mapper)
        {
            userTypePermissionsService = userTypePermissionService;
            mapper = _mapper;
        }

        [HttpGet(Name = "GetAllUserTypePermissions")]
        public async Task<IActionResult> GetAllUserTypePermissionsAsync()
        {
            var listUserTypePermissions = await userTypePermissionsService.GetAllUserTypePermissionsAsync();
            var listaUserTypePermissionsDto = new List<UserType_PermissionsDto>();

            foreach (var UserXPermission in listUserTypePermissions)
            {
                listaUserTypePermissionsDto.Add(mapper.Map<UserType_PermissionsDto>(UserXPermission));
            }
            return Ok(listaUserTypePermissionsDto);
        }

        [HttpGet("{id1}/{id2}", Name = "GetUserTypePermissionById")]
        public async Task<IActionResult> GetUserTypePermissionByIdAsync(int id1, int id2)
        {
            var userTypePermission = await userTypePermissionsService.GetUserTypePermissionByIdAsync(id1, id2);
            if (userTypePermission == null)
                return NotFound();
            
            var userTypePermissionDto = mapper.Map<UserType_PermissionsDto>(userTypePermission);
            return Ok(userTypePermissionDto);
        }

        [HttpPost(Name = "CreateUserTypePermission")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateUserTypePermissionAsync([FromBody] UserType_PermissionsDto userType_PermissionsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTypePermission = mapper.Map<UserTypePermissions>(userType_PermissionsDto);
            var createdUserXPermission = await userTypePermissionsService.CreateUserTypePermissionAsync(userTypePermission);

            return Ok(userTypePermission);
        }

        [HttpPut("{id1}/{id2}", Name = "UpdateUserTypePermission")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserTypePermission(int id1, int id2, [FromBody] UserType_PermissionsDto userType_PermissionsDto)
        {
            if (id1 != userType_PermissionsDto.Id_Usertype || id2 != userType_PermissionsDto.Id_permission)
                return BadRequest();

            var userTypePermission = mapper.Map<UserTypePermissions>(userType_PermissionsDto);
            var updateSuccess = await userTypePermissionsService.UpdateUserTypePermissionAsync(userTypePermission);

            return NoContent(); 
        }

        [HttpDelete("{id1}/{id2}", Name = "DeleteUserPermissionsController")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUserPermissions(int id1, int id2)
        {
            // Current permission by Id
            var existingPermission = await GetUserTypePermissionByIdAsync(id1, id2);
            if (existingPermission == null)
                return NotFound();

            await userTypePermissionsService.DeleteUserTypePermissionAsyncId(id1, id2);

            return NoContent();
        }
    }
}
