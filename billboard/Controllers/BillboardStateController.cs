using billboard.Model;
using billboard.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillboardStateController : ControllerBase
    {
        private readonly IBillboardStateService _billboardStateService;

        public BillboardStateController(IBillboardStateService billboardStateService)
        {
            _billboardStateService = billboardStateService;
        }

        [HttpGet(Name = "GetAllBillboardStates")]
        public Task<IEnumerable<BillboardState>> GetAllBillboardStatesAsync()
        {
            return _billboardStateService.GetAllBillboardStatesAsync();
        }

        [HttpGet("{id}", Name = "GetBillboardStateById")]
        public async Task<ActionResult<BillboardState>> GetBillboardStateByIdAsync(int id)
        {
            var billboardState = await _billboardStateService.GetBillboardStateByIdAsync(id);
            if (billboardState == null)
                return NotFound();

            return Ok(billboardState);
        }

        [HttpPost(Name = "CreateBillboardState")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> CreateBillboardStateAsync(BillboardState billboardState)
        {
            await _billboardStateService.CreateBillboardStateAsync(billboardState);
            return Ok();
        }

        [HttpPut("{id}", Name = "UpdateBillboardState")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBillboardState(int id, [FromBody] BillboardState billboardState)
        {
            if (id != billboardState.IdState)
                return BadRequest();

            await _billboardStateService.UpdateBillboardStateAsync(billboardState);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteBillboardState")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBillboardState(int id)
        {
            // Current billboardState by Id
            var existingBillboardState = await GetBillboardStateByIdAsync(id);
            if (existingBillboardState == null)
                return NotFound();

            await _billboardStateService.DeleteBillboardStateAsync(id);

            return NoContent();
        }
    }
}
