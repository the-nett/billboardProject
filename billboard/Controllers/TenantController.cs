using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService tenantService;
        public TenantController(ITenantService _tenantService)
        {
            tenantService = _tenantService;
        }

        [HttpGet(Name = "GetAllTenants")]
        public Task<IEnumerable<Model.Tenant>> GetAllTenantsAsync()
        {
            return tenantService.GetAllTenantsAsync();
        }

        [HttpGet("{id}", Name = "GetTenantById")]
        public async Task<ActionResult<Model.Tenant>> GetTenantByIdAsync(int id)
        {
            var tenant = await tenantService.GetTenantByIdAsync(id);
            if (tenant == null)
                return NotFound();

            return Ok(tenant);
        }

        [HttpPost(Name = "CreateTenant")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreateTenantAsync(Model.Tenant tenant)
        {
            await tenantService.CreateTenantAsync(tenant);
        }

        [HttpPut("{id}", Name = "UpdateTenant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTenant(int id, [FromBody] Model.Tenant tenant)
        {
            if (id != tenant.IdTenant)
                return BadRequest();

            await tenantService.UpdateTenantAsync(tenant);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTenant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTenant(int id)
        {
            // Current tenant by Id
            var existingTenant = await GetTenantByIdAsync(id);
            if (existingTenant == null)
                return NotFound();

            await tenantService.DeleteTenantAsync(id);

            return NoContent();
        }
    }
}
