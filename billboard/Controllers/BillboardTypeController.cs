using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillboardTypeController : ControllerBase
    {
        private readonly IBillboardTypeService billboardTypeService;

        public BillboardTypeController(IBillboardTypeService _billboardTypeService)
        {
            billboardTypeService = _billboardTypeService;
        }

        [HttpGet(Name = "GetAllBillboardTypes")]
        public Task<IEnumerable<BillboardType>> GetAllBillboardTypesAsync()
        {
            return billboardTypeService.GetAllBillboardTypesAsync();
        }

        [HttpGet("{id}", Name = "GetBillboardTypeById")]
        public async Task<ActionResult<BillboardType>> GetBillboardTypeByIdAsync(int id)
        {
            var billboardType = await billboardTypeService.GetBillboardTypeByIdAsync(id);
            if (billboardType == null)
                return NotFound();

            return Ok(billboardType);
        }

        [HttpPost(Name = "CreateBillboardType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateBillboardTypeAsync(BillboardType billboardType)
        {
            await billboardTypeService.CreateBillboardTypeAsync(billboardType);
            return CreatedAtRoute("GetBillboardTypeById", new { id = billboardType.BillboardTypeId }, billboardType);
        }

        [HttpPut("{id}", Name = "UpdateBillboardType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBillboardType(int id, [FromBody] BillboardType billboardType)
        {
            if (id != billboardType.BillboardTypeId)
                return BadRequest();

            await billboardTypeService.UpdateBillboardTypeAsync(billboardType);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteBillboardType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBillboardType(int id)
        {
            // Current billboardType by Id
            var existingBillboardType = await GetBillboardTypeByIdAsync(id);
            if (existingBillboardType == null)
                return NotFound();

            await billboardTypeService.DeleteBillboardTypeAsync(id);

            return NoContent();
        }
    }
}
