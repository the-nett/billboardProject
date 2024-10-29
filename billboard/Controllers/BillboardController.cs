using AutoMapper;
using billboard.Model;
using billboard.Model.Dtos.Billboard;
using billboard.Model.Dtos.Company;
using billboard.services;
using billboard.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillboardController : ControllerBase
    {
        private readonly IBillboardService billboardService;
        private readonly IMapper mapper;
        public BillboardController(IBillboardService _billboardService, IMapper _mapper)
        {
            billboardService = _billboardService;
            mapper = _mapper;
        }

        [HttpGet(Name = "GetAllBillboards")]
        public async Task<IActionResult> GetAllBillboardsAsync()
        {
            var listBillboards = await billboardService.GetAllBillboardsAsync();
            var listBillboardDto = new List<ShowBillboardDto>();
            foreach (var billboard in listBillboards)
            {
                listBillboardDto.Add(mapper.Map<ShowBillboardDto>(billboard));
            }

            return Ok(listBillboardDto);
        }

        [HttpGet("{id}", Name = "GetBillboardById")]
        public async Task<IActionResult> GetBillboardByIdAsync(int id)
        {
            var billboard = await billboardService.GetBillboardByIdAsync(id);
            if (billboard == null)
                return NotFound();
            var BillboardToDto = mapper.Map<ShowBillboardDto>(billboard);
            return Ok(BillboardToDto);
        }

        [HttpPost(Name = "CreateBillboard")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateBillboardAsync([FromBody] CreateBillboardDto createBillboardDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var billboard = mapper.Map<Billboard>(createBillboardDto);

            var createdBillboard = await billboardService.CreateBillboardAsync(billboard);
            return Ok();
        }

        [HttpPut("{id}", Name = "UpdateBillboard")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBillboard(int id, [FromBody] ShowBillboardDto showBillboardDto)
        {
            if (id != showBillboardDto.IdBillboard)
                return BadRequest();

            var billboard = mapper.Map<Billboard>(showBillboardDto);

            var updatedbillboard = await billboardService.UpdateBillboardAsync(billboard);

            return Ok();
        }

        [HttpDelete("{id}", Name = "DeleteBillboard")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task DeleteBillboard(int id)
        {
            // Obtener valla actual por Id
            var existingBillboard = await billboardService.GetBillboardByIdAsync(id);
            if (existingBillboard != null)
            {
                // Marcar el estado de eliminación
                existingBillboard.StateDelete = true;

                await billboardService.DeleteBillboardAsync(id);
            }
            else
            {
                throw new Exception("No se pudo eliminar el usuario");
            }
        }
    }
}
