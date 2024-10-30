using AutoMapper;
using billboard.Model;
using billboard.Model.Dtos.Tenant;
using billboard.Model.Dtos.User;
using billboard.services;
using billboard.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService tenantService;
        private readonly IMapper mapper;
        public TenantController(ITenantService _tenantService, IMapper _mapper)
        {
            tenantService = _tenantService;
            mapper = _mapper;
        }

        [HttpGet(Name = "GetAllTenants")]
        public async Task<IActionResult> GetAllTenantsAsync()
        {
            var listTenats = await tenantService.GetAllTenantsAsync();
            var listaTenantDto = new List<TenantDto>();

            foreach (var tenant in listTenats)
            {
                listaTenantDto.Add(mapper.Map<TenantDto>(tenant));
            }

            return Ok(listaTenantDto);
        }

        [HttpGet("{id}", Name = "GetTenantById")]
        public async Task<IActionResult> GetTenantByIdAsync(int id)
        {
            var tenant = await tenantService.GetTenantByIdAsync(id);
            if (tenant == null)
                return NotFound();

            var userdto = mapper.Map<TenantDto>(tenant);
            return Ok(userdto);
        }

        [HttpPost(Name = "CreateTenant")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateTenantAsync([FromBody] CreateTenantDto createTenantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tenant = mapper.Map<Tenant>(createTenantDto);
            var createTenant = await tenantService.CreateTenantAsync(tenant);
            return Ok();
        }

        [HttpPut("{id}", Name = "UpdateTenant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTenant(int id, [FromBody] TenantDto tenantDto)
        {
            if (id != tenantDto.IdTenant)
                return BadRequest();

            var tenant = mapper.Map<Tenant>(tenantDto);

            var updatetENANT = await tenantService.UpdateTenantAsync(tenant);

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
