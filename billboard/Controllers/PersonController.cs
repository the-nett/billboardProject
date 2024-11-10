using AutoMapper;
using billboard.Model;
using billboard.Model.Dtos.Person;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        private readonly IMapper mapper;
        public PersonController(IPersonService _personService, IMapper _mapper)
        {
            personService = _personService;
            mapper = _mapper;
        }

        [HttpGet(Name = "GetAllPeople")]
        public async Task<IActionResult> GetAllPeopleAsync()
        {
            var listPersons = await personService.GetAllPeopleAsync();
            var listPersonsDto = new List<PersonDto>();
            foreach (var person in listPersons)
            {
                listPersonsDto.Add(mapper.Map<PersonDto>(person));
            }

            return Ok(listPersonsDto);
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        public async Task<IActionResult> GetPersonByIdAsync(int id)
        {
            var person = await personService.GetPersonByIdAsync(id);
            if (person == null)
                return NotFound();

            var personToDto = mapper.Map<PersonDto>(person);
            return Ok(personToDto);
        }

        [HttpPost(Name = "CreatePerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreatePersonAsync([FromBody] CreatePersonDto createPersonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var person = mapper.Map<Person>(createPersonDto);

            var createdPeson = await personService.CreatePersonAsync(person);
            return Ok(createdPeson.IdPeople);
        }

        [HttpPut("{id}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] PersonDto personDto)
        {
            if (id != personDto.IdPeople)
                return BadRequest();

            var person = mapper.Map<Person>(personDto);

            var updatePerson = await personService.UpdatePersonAsync(person);

            return CreatedAtAction("GetPermissionById", new { id = person.IdPeople }, person);
        }

        [HttpDelete("{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePerson(int id)
        {
            // Current person by Id
            var existingPerson = await GetPersonByIdAsync(id);
            if (existingPerson == null)
                return NotFound();

            await personService.DeletePersonAsync(id);

            return NoContent();
        }
    }
}
