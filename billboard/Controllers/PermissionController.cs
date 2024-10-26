using AutoMapper;
using billboard.Model;
using billboard.Model.Dtos.Permissions;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService permissionService;
        private readonly IMapper mapper;

        public PermissionController(IPermissionService _permissionService, IMapper _mapper)
        {
            permissionService = _permissionService;
            mapper = _mapper;
        }

        [HttpGet(Name = "GetAllPermissions")]
        public async Task<IActionResult> GetPermissionsAsync()
        {
            var listPermissions = await permissionService.GetAllPermissionsAsync();
            var listaPermissionsDto = new List<PermissionDto>();

            foreach (var permis in listPermissions)
            {
                listaPermissionsDto.Add(mapper.Map<PermissionDto>(permis));
            }

            return Ok(listaPermissionsDto);
        }

        [HttpGet("{id}", Name = "GetPermissionById")]
        public async Task<IActionResult> GetPermissionByIdAsync(int id)
        {
            var permission = await permissionService.GetPermissionByIdAsync(id);
            if (permission == null)
                return NotFound();

            var permiddiondto = mapper.Map<PermissionDto>(permission);
            return Ok(permiddiondto);
        }

        [HttpPost(Name = "CreatePermission")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreatePermissionAsync([FromBody] CreatePermissionDto createPermissionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var permission = mapper.Map<Permission>(createPermissionDto);

            var createdPermission = await permissionService.CreatePermissionAsync(permission);
            return CreatedAtAction("GetPermissionById", new { id = permission.Id_Permission }, permission);
        }

        [HttpPut("{id}", Name = "UpdatePermission")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePermission(int id, [FromBody] PermissionDto permissionDto)
        {
            if (id != permissionDto.Id_Permission)
                return BadRequest();

            var permission = mapper.Map<Permission>(permissionDto);

            Permission updatePermission = await permissionService.UpdatePermissionAsync(permission);

            return CreatedAtAction("GetPermissionById", new { id = permission.Id_Permission }, permission);
        }

        [HttpDelete("{id}", Name = "DeletePermission")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePermission(int id)
        {
            // Current permission by Id
            var existingPermission = await GetPermissionByIdAsync(id);
            if (existingPermission == null)
                return NotFound();

            await permissionService.DeletePermissionAsync(id);

            return NoContent();
        }
    }
}
