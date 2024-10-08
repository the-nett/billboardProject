﻿using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessorController : ControllerBase
    {
        private readonly ILessorService lessorService;
        public LessorController(ILessorService _lessorService)
        {
            lessorService = _lessorService;
        }

        [HttpGet(Name = "GetAllLessors")]
        public Task<IEnumerable<Lessor>> GetAllLessorsAsync()
        {
            return lessorService.GetAllLessorsAsync();
        }
        [HttpGet("{id}", Name = "GetLessorById")]
        public async Task<ActionResult<Lessor>> GetLessorByIdAsync(int id)
        {
            var lessor = await lessorService.GetLessorByIdAsync(id);
            if (lessor == null)
                return NotFound();

            return Ok(lessor);
        }

        [HttpPost(Name = "CreateLessor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreateLessorAsync(Lessor lessor)
        {
            await lessorService.CreateLessorAsync(lessor);
        }
    }
}