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
        public Task<IEnumerable<Industry>> GetAllIndustriesAsync()
        {
            return industryService.GetAllIndustriesAsync();
        }
        [HttpGet("{id}", Name = "GetIndustryById")]
        public async Task<ActionResult<Industry>> GetIndustryByIdAsync(int id)
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
        public async Task CreateIndustryAsync(Industry industry)
        {
            await industryService.CreateIndustryAsync(industry);
        }


    }
}
