using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustryController : ControllerBase
    {
        private readonly IIndustryService industryService;

        public IndustryController(IIndustryService _industryService)
        {
            industryService = _industryService;
        }

        [HttpGet(Name = "GetAllIndustries")]
        public Task<IEnumerable<Model.Industry>> GetAllIndustriesAsync()
        {
            return industryService.GetAllIndustriesAsync();
        }

        [HttpGet("{id}", Name = "GetIndustryById")]
        public async Task<ActionResult<Model.Industry>> GetIndustryByIdAsync(int id)
        {
            var industry = await industryService.GetIndustryByIdAsync(id);
            if (industry == null)
                return NotFound();

            return Ok(industry);
        }

        [HttpPost(Name = "CreateIndustry")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateIndustryAsync(Model.Industry industry)
        {
            await industryService.CreateIndustryAsync(industry);
            return Ok(industry);
        }

        [HttpPut("{id}", Name = "UpdateIndustry")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateIndustry(int id, [FromBody] Model.Industry industry)
        {
            if (id != industry.IndustryId)
                return BadRequest();

            await industryService.UpdateIndustryAsync(industry);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteIndustry")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteIndustry(int id)
        {
            // Current industry by Id
            var existingIndustry = await GetIndustryByIdAsync(id);
            if (existingIndustry == null)
                return NotFound();

            await industryService.DeleteIndustryAsync(id);

            return NoContent();
        }
    }
}
