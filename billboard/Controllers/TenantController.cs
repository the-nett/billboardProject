using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

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
        public Task<IEnumerable<Tenant>> GetAllTenantsAsync()
        {
            return tenantService.GetAllTenantsAsync();
        }
        [HttpGet("{id}", Name = "GetTenantById")]
        public async Task<ActionResult<Tenant>> GetTenantByIdAsync(int id)
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
        public async Task CreateTenantAsync(Tenant tenant)
        {
            await tenantService.CreateTenantAsync(tenant);
        }
    }
}
