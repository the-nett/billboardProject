using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService permissionService;

        public PermissionController(IPermissionService _permissionService)
        {
            permissionService = _permissionService;
        }

        [HttpGet(Name = "GetAllPermissions")]
        public Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            return permissionService.GetAllPermissionsAsync();
        }

        [HttpGet("{id}", Name = "GetPermissionById")]
        public async Task<ActionResult<Permission>> GetPermissionByIdAsync(int id)
        {
            var permission = await permissionService.GetPermissionByIdAsync(id);
            if (permission == null)
                return NotFound();

            return Ok(permission);
        }

        [HttpPost(Name = "CreatePermission")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreatePermissionAsync(Permission permission)
        {
            await permissionService.CreatePermissionAsync(permission);
        }

        [HttpPut("{id}", Name = "UpdatePermission")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePermission(int id, [FromBody] Permission permission)
        {
            if (id != permission.Id_Permission)
                return BadRequest();

            await permissionService.UpdatePermissionAsync(permission);

            return NoContent();
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
