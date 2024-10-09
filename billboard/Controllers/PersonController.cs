using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        public PersonController(IPersonService _personService)
        {
            personService = _personService;
        }

        [HttpGet(Name = "GetAllPeople")]
        public Task<IEnumerable<Model.Person>> GetAllPeopleAsync()
        {
            return personService.GetAllPeopleAsync();
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        public async Task<ActionResult<Model.Person>> GetPersonByIdAsync(int id)
        {
            var person = await personService.GetPersonByIdAsync(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost(Name = "CreatePerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreatePersonAsync(Model.Person person)
        {
            await personService.CreatePersonAsync(person);
        }

        [HttpPut("{id}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] Model.Person person)
        {
            if (id != person.IdPeople)
                return BadRequest();

            await personService.UpdatePersonAsync(person);

            return NoContent();
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
