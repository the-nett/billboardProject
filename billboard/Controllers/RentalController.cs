using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService rentalService;

        public RentalController(IRentalService _rentalService)
        {
            rentalService = _rentalService;
        }

        [HttpGet(Name = "GetAllRentals")]
        public Task<IEnumerable<Model.Rental>> GetAllRentalsAsync()
        {
            return rentalService.GetAllRentalsAsync();
        }

        [HttpGet("{id}", Name = "GetRentalById")]
        public async Task<ActionResult<Model.Rental>> GetRentalByIdAsync(int id)
        {
            var rental = await rentalService.GetRentalByIdAsync(id);
            if (rental == null)
                return NotFound();

            return Ok(rental);
        }

        [HttpPost(Name = "CreateRental")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreateRentalAsync(Model.Rental rental)
        {
            await rentalService.CreateRentalAsync(rental);
        }

        [HttpPut("{id}", Name = "UpdateRental")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRental(int id, [FromBody] Model.Rental rental)
        {
            if (id != rental.IdRental)
                return BadRequest();

            await rentalService.UpdateRentalAsync(rental);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteRental")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRental(int id)
        {
            // Current rental by Id
            var existingRental = await GetRentalByIdAsync(id);
            if (existingRental == null)
                return NotFound();

            await rentalService.DeleteRentalAsync(id);

            return NoContent();
        }
    }
}
