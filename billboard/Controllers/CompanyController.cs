//using AutoMapper;
//using billboard.Model;
//using billboard.Model.Dtos.Company;
//using billboard.Services;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Net;
//using System.Security;
//using System.Threading.Tasks;

//namespace billboard.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CompanyController : ControllerBase
//    {
//        private readonly ICompanyService companyService;
//        private readonly IMapper mapper;
//        public CompanyController(ICompanyService _companyService, IMapper _mapper)
//        {
//            companyService = _companyService;
//            mapper = _mapper;
//        }

//        [HttpGet(Name = "GetAllCompanies")]
//        public async Task<IActionResult> GetAllCompaniesAsync()
//        {
//            var listCompanies = await companyService.GetAllCompaniesAsync();
//            var listCompaniesDto = new List<ShowCompanyDto>();
//            foreach (var company in listCompanies)
//            {
//                listCompaniesDto.Add(mapper.Map<ShowCompanyDto>(company));
//            }

//            return Ok(listCompaniesDto);
//        }

//        [HttpGet("{id}", Name = "GetCompanyById")]
//        public async Task<IActionResult> GetCompanyByIdAsync(int id)
//        {
//            var company = await companyService.GetCompanyByIdAsync(id);
//            if (company == null)
//                return NotFound();

//            var personToDto = mapper.Map<ShowCompanyDto>(company);
//            return Ok(personToDto);
//        }

//        [HttpPost(Name = "CreateCompany")]
//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//        public async Task<IActionResult> CreateCompanyAsync ([FromBody] RegisterCompanyDto registerCompanyDto)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            var company = mapper.Map<Company>(registerCompanyDto);

//            var createdCompany = await companyService.CreateCompanyAsync(company);
//            return Ok();
//        }

//        [HttpPut("{id}", Name = "UpdateCompany")]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<IActionResult> UpdateCompany(int id, [FromBody] UpdateCompany updateCompany)
//        {
//            if (id != updateCompany.IdCompany)
//                return BadRequest();

//            var company = mapper.Map<Company>(updateCompany);

//            var updatedCompany = await companyService.UpdateCompanyAsync(company);

//            return Ok();
//        }

//        [HttpDelete("{id}", Name = "DeleteCompany")]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task DeleteCompany(int id)
//        {
//            // Current company by Id
//            var existingCompany = await companyService.GetCompanyByIdAsync(id);
//            if (existingCompany != null)
//            {
//                // Marcar el estado de eliminación
//                existingCompany.StateDelete = true;

//                await companyService.DeleteCompanyAsync(id);
//            }
//            else
//            {
//                throw new Exception("No se pudo eliminar el usuario");
//            }
//        }
//        [HttpPost(Name = "loginCompany")]
//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public async Task<IActionResult> LoginCompany([FromBody] LoginCompanyDto loginCompanyDto)
//        {

//            var responseLoginCompany = await companyService.LoginCompany(loginCompanyDto);

//            if (responseLoginCompany == null || responseLoginCompany.company == null || string.IsNullOrEmpty(responseLoginCompany.Token))
//            {
//                return BadRequest("Invalid login credentials.");
//            }

//            return Ok(new
//            {
//                company = responseLoginCompany.company,
//                Token = responseLoginCompany.Token
//            });
//        }
//    }
//}
