using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillboardController : ControllerBase
    {
        private readonly IBillboardService billboardService;
        public BillboardController(IBillboardService _billboardService)
        {
            billboardService = _billboardService;
        }

        [HttpGet(Name = "GetAllBillboards")]
        public Task<IEnumerable<Model.Billboard>> GetAllBillboardsAsync()
        {
            return billboardService.GetAllBillboardsAsync();
        }

        [HttpGet("{id}", Name = "GetBillboardById")]
        public async Task<ActionResult<Model.Billboard>> GetBillboardByIdAsync(int id)
        {
            var billboard = await billboardService.GetBillboardByIdAsync(id);
            if (billboard == null)
                return NotFound();

            return Ok(billboard);
        }

        [HttpPost(Name = "CreateBillboard")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreateBillboardAsync(Model.Billboard billboard)
        {
            await billboardService.CreateBillboardAsync(billboard);
        }

        [HttpPut("{id}", Name = "UpdateBillboard")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBillboard(int id, [FromBody] Model.Billboard billboard)
        {
            if (id != billboard.IdBillboard)
                return BadRequest();

            await billboardService.UpdateBillboardAsync(billboard);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteBillboard")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBillboard(int id)
        {
            // Obtener valla actual por Id
            var existingBillboard = await GetBillboardByIdAsync(id);
            if (existingBillboard == null)
                return NotFound();

            await billboardService.DeleteBillboardAsync(id);

            return NoContent();
        }
    }
}
