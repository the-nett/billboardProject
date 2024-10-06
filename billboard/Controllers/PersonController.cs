using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet(Name = "GetAllPerson")]
        public Task<IEnumerable<Person>> GetAllPersonAsync()
        {
            return personService.GetAllPersonAsync();
        }

        [HttpPost(Name = "CreatePerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreatePersonAsync(Person person)
        {
            await personService.CreatePersonAsync(person);
        }
    }
    
}
