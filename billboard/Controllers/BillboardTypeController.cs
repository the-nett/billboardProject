using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task CreateBillboardTypeAsync(BillboardType billboardType)
        {
            await billboardTypeService.CreateBillboardTypeAsync(billboardType);
        }
    }
}
