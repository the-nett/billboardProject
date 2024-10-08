using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillboardStateController : ControllerBase
    {
        private readonly IBillboardStateService billboardStateService;
        public BillboardStateController(IBillboardStateService _billboardStateService)
        {
            billboardStateService = _billboardStateService;
        }

        [HttpGet(Name = "GetAllBillboardStates")]
        public Task<IEnumerable<BillboardState>> GetAllBillboardStatesAsync()
        {
            return billboardStateService.GetAllBillboardStatesAsync();
        }

        [HttpGet("{id}", Name = "GetBillboardStateById")]
        public async Task<ActionResult<BillboardState>> GetBillboardStateByIdAsync(int id)
        {
            var billboardState = await billboardStateService.GetBillboardStateByIdAsync(id);
            if (billboardState == null)
                return NotFound();

            return Ok(billboardState);
        }

        [HttpPost(Name = "CreateBillboardState")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreateBillboardStateAsync(BillboardState billboardState)
        {
            await billboardStateService.CreateBillboardStateAsync(billboardState);
        }
    }
}
