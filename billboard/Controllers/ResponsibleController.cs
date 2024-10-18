using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsibleController : ControllerBase
    {
        private readonly IResponsibleService responsibleService;

        public ResponsibleController(IResponsibleService _responsibleService)
        {
            responsibleService = _responsibleService;
        }

        [HttpGet(Name = "GetAllResponsibles")]
        public Task<IEnumerable<Model.Responsible>> GetAllResponsiblesAsync()
        {
            return responsibleService.GetAllResponsiblesAsync();
        }

        [HttpGet("{id}", Name = "GetResponsibleById")]
        public async Task<ActionResult<Model.Responsible>> GetResponsibleByIdAsync(int id)
        {
            var responsible = await responsibleService.GetResponsibleByIdAsync(id);
            if (responsible == null)
                return NotFound();

            return Ok(responsible);
        }

        [HttpPost(Name = "CreateResponsible")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreateResponsibleAsync(Model.Responsible responsible)
        {
            await responsibleService.CreateResponsibleAsync(responsible);
        }

        [HttpPut("{id}", Name = "UpdateResponsible")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateResponsible(int id, [FromBody] Model.Responsible responsible)
        {
            if (id != responsible.IdResponsible)
                return BadRequest();

            await responsibleService.UpdateResponsibleAsync(responsible);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteResponsible")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteResponsible(int id)
        {
            // Current responsible by Id
            var existingResponsible = await GetResponsibleByIdAsync(id);
            if (existingResponsible == null)
                return NotFound();

            await responsibleService.DeleteResponsibleAsync(id);

            return NoContent();
        }
    }
}
