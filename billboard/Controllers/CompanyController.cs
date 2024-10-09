using billboard.Model;
using billboard.Services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        public CompanyController(ICompanyService _companyService)
        {
            companyService = _companyService;
        }

        [HttpGet(Name = "GetAllCompanies")]
        public Task<IEnumerable<Model.Company>> GetAllCompaniesAsync()
        {
            return companyService.GetAllCompaniesAsync();
        }

        [HttpGet("{id}", Name = "GetCompanyById")]
        public async Task<ActionResult<Model.Company>> GetCompanyByIdAsync(int id)
        {
            var company = await companyService.GetCompanyByIdAsync(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        [HttpPost(Name = "CreateCompany")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreateCompanyAsync(Model.Company company)
        {
            await companyService.CreateCompanyAsync(company);
        }

        [HttpPut("{id}", Name = "UpdateCompany")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] Model.Company company)
        {
            if (id != company.IdCompany)
                return BadRequest();

            await companyService.UpdateCompanyAsync(company);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCompany")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            // Current company by Id
            var existingCompany = await GetCompanyByIdAsync(id);
            if (existingCompany == null)
                return NotFound();

            await companyService.DeleteCompanyAsync(id);

            return NoContent();
        }
    }
}
