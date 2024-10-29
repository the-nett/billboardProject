using AutoMapper;
using billboard.Model;
using billboard.Model.Dtos.Company;
using billboard.Model.Dtos.Person;
using billboard.Model.Dtos.Rental;
using billboard.services;
using billboard.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService rentalService;
        private readonly IMapper mapper;

        public RentalController(IRentalService _rentalService, IMapper _mapper)
        {
            rentalService = _rentalService;
            mapper = _mapper;
        }

        [HttpGet(Name = "GetAllRentals")]
        public async Task<IActionResult> GetAllRentalsAsync()
        {
            var listRentals = await rentalService.GetAllRentalsAsync();
            var listRentalsDto = new List<ShowRentalDto>();
            foreach (var rental in listRentals)
            {
                listRentalsDto.Add(mapper.Map<ShowRentalDto>(rental));
            }

            return Ok(listRentalsDto);
        }

        [HttpGet("{id}", Name = "GetRentalById")]
        public async Task<IActionResult> GetRentalByIdAsync(int id)
        {
            var rental = await rentalService.GetRentalByIdAsync(id);
            if (rental == null)
                return NotFound();

            var rentalToDto = mapper.Map<ShowRentalDto>(rental);
            return Ok(rentalToDto);
        }

        [HttpPost(Name = "CreateRental")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateRentalAsync ([FromBody] CreateRentalDto createRentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var rental = mapper.Map<Rental>(createRentalDto);

            var createdrental = await rentalService.CreateRentalAsync(rental);

            return Ok();
        }

        [HttpPut("{id}", Name = "UpdateRental")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRental(int id, [FromBody] ShowRentalDto showRentalDto)
        {
            if (id != showRentalDto.IdRental)
                return BadRequest();
            var rental = mapper.Map<Rental>(showRentalDto);

            var updatedRental = await rentalService.UpdateRentalAsync(rental);

            return Ok();
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
