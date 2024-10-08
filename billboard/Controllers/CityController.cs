using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;
        public CityController(ICityService _cityService)
        {
            cityService = _cityService;
        }

        [HttpGet(Name = "GetAllCities")]
        public Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return cityService.GetAllCitiesAsync();
        }
        [HttpGet("{id}", Name = "GetCityById")]
        public async Task<ActionResult<City>> GetCityByIdAsync(int id)
        {
            var city = await cityService.GetCityByIdAsync(id);
            if (city == null)
                return NotFound();

            return Ok(city);
        }

        [HttpPost(Name = "CreateCity")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreateCityAsync(City city)
        {
            await cityService.CreateCityAsync(city);
        }
        [HttpPut("{id}", Name = "Updatecity")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] City city)
        {
            if (id != city.CityId)
                return BadRequest();

            await cityService.UpdateCityAsync(city);
            return NoContent();
        }
    }
}
