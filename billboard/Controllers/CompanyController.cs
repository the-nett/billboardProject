using AutoMapper;
using billboard.Model;
using billboard.Model.Dtos;
using billboard.services;
using billboard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace billboard.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService _companyService, IMapper mapper)
        {
            companyService = _companyService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllCompanies")]
        public Task<IEnumerable<Model.Company>> GetAllCompaniesAsync()
        {
            return companyService.GetAllCompaniesAsync();
        }

        [HttpGet("{id}", Name = "GetCompanyById")]
        public async Task<IActionResult> GetCompanyByIdAsync(int id)
        {
            var company = await companyService.GetCompanyByIdAsync(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }
        [HttpPost(Name = "RegisterCompany")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public IActionResult CreateCompany([FromBody] string Company_name, [FromBody] int industry, [FromBody] string nit, [FromBody] string Owner_name, [FromBody] string Company_Direction, [FromBody] string city, [FromBody] string phone_number, [FromBody] string corporate_email, [FromBody] int responsible, [FromBody] string password, [FromBody] int Usertype)
        {
            // Validaciones adicionales (opcional)
            if (string.IsNullOrEmpty(Company_name) || string.IsNullOrEmpty(nit) || string.IsNullOrEmpty(Owner_name) || string.IsNullOrEmpty(Company_Direction) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(phone_number) || string.IsNullOrEmpty(corporate_email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Todos los campos son obligatorios.");
            }

            // Llamada al servicio para crear la compañía
            var result = companyService.CreateCompany(Company_name, industry, nit, Owner_name, Company_Direction, city, phone_number, corporate_email, responsible, password, Usertype);

        }


    }
}
