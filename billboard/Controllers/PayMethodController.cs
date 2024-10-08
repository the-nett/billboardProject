using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayMethodController : ControllerBase
    {
        private readonly IPayMethodService paymethodService;
        public PayMethodController(IPayMethodService _paymethodService)
        {
            paymethodService = _paymethodService;
        }

        [HttpGet(Name = "GetAllPayMethods")]
        public Task<IEnumerable<PayMethods>> GetAllPayMethodsAsync()
        {
            return paymethodService.GetAllPayMethodsAsync();
        }
        [HttpGet("{id}", Name = "GetPayMethodById")]
        public async Task<ActionResult<PayMethods>> GetPayMethodByIdAsync(int id)
        {
            var paymethod = await paymethodService.GetPayMethodByIdAsync(id);
            if (paymethod == null)
                return NotFound();

            return Ok(paymethod);
        }

        [HttpPost(Name = "CreatePayMethod")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreatePayMethodAsync(PayMethods paymethods)
        {
            await paymethodService.CreatePayMethodAsync(paymethods);
        }
        [HttpPut("{id}", Name = "UpdatePayMethod")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePayMethod(int id, [FromBody] PayMethods paymethod)
        {
            if (id != paymethod.IdPayMethod)
                return BadRequest();

            await paymethodService.UpdatePayMethodAsync(paymethod);
            return NoContent();
        }
    }
}
