using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessorController : ControllerBase
    {
        private readonly ILessorService lessorService;
        public LessorController(ILessorService _lessorService)
        {
            lessorService = _lessorService;
        }

        [HttpGet(Name = "GetAllLessors")]
        public Task<IEnumerable<Model.Lessor>> GetAllLessorsAsync()
        {
            return lessorService.GetAllLessorsAsync();
        }

        [HttpGet("{id}", Name = "GetLessorById")]
        public async Task<ActionResult<Model.Lessor>> GetLessorByIdAsync(int id)
        {
            var lessor = await lessorService.GetLessorByIdAsync(id);
            if (lessor == null)
                return NotFound();

            return Ok(lessor);
        }

        [HttpPost(Name = "CreateLessor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreateLessorAsync(Model.Lessor lessor)
        {
            await lessorService.CreateLessorAsync(lessor);
        }

        [HttpPut("{id}", Name = "UpdateLessor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateLessor(int id, [FromBody] Model.Lessor lessor)
        {
            if (id != lessor.IdLessor)
                return BadRequest();

            await lessorService.UpdateLessorAsync(lessor);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteLessor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLessor(int id)
        {
            // Current lessor by Id
            var existingLessor = await GetLessorByIdAsync(id);
            if (existingLessor == null)
                return NotFound();

            await lessorService.DeleteLessorAsync(id);

            return NoContent();
        }
    }
}
