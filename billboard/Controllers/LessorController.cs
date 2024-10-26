using AutoMapper;
using billboard.Model;
using billboard.Model.Dtos.Lessor;
using billboard.services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessorController : ControllerBase
    {
        private readonly ILessorService lessorService;
        private readonly IMapper mapper;
        public LessorController(ILessorService _lessorService, IMapper _mapper)
        {
            lessorService = _lessorService;
            mapper = _mapper;
        }

        [HttpGet(Name = "GetAllLessors")]
        public async Task<IActionResult> GetAllLessorsAsync()
        {
            var listLessors = await lessorService.GetAllLessorsAsync();
            var listaLessorDto = new List<LessorDto>();

            foreach (var lessor in listLessors)
            {
                listaLessorDto.Add(mapper.Map<LessorDto>(lessor));
            }

            return Ok(listaLessorDto);
        }

        [HttpGet("{id}", Name = "GetLessorById")]
        public async Task<IActionResult> GetLessorByIdAsync(int id)
        {
            var lessor = await lessorService.GetLessorByIdAsync(id);
            if (lessor == null)
                return NotFound();
            var lessordto = mapper.Map<LessorDto>(lessor);
            return Ok(lessordto);
        }

        [HttpPost(Name = "CreateLessor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateLessorAsync ([FromBody] CreateLessorDto createLessorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lessor = mapper.Map<Lessor>(createLessorDto);
            var createLessor = await lessorService.CreateLessorAsync(lessor);
            return Ok();
        }

        [HttpPut("{id}", Name = "UpdateLessor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateLessor(int id, [FromBody] LessorDto lessorDto)
        {
            if (id != lessorDto.IdLessor)
                return BadRequest();

            var lessor = mapper.Map<Lessor>(lessorDto);

            var updatetLessor = await lessorService.UpdateLessorAsync(lessor);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteLessor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLessor(int id)
        {
            // Current lessor by Id
            var existingLessor = await GetLessorByIdAsync(id);
            if (existingLessor == null)
                return NotFound();

            await lessorService.DeleteLessorAsync(id);

            return NoContent();
        }
    }
}
