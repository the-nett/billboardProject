using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayMethodController : ControllerBase
    {
        private readonly IPayMethodService payMethodService;
        public PayMethodController(IPayMethodService _payMethodService)
        {
            payMethodService = _payMethodService;
        }

        [HttpGet(Name = "GetAllPayMethods")]
        public Task<IEnumerable<Model.PayMethods>> GetAllPayMethodsAsync()
        {
            return payMethodService.GetAllPayMethodsAsync();
        }

        [HttpGet("{id}", Name = "GetPayMethodById")]
        public async Task<ActionResult<Model.PayMethods>> GetPayMethodByIdAsync(int id)
        {
            var payMethod = await payMethodService.GetPayMethodByIdAsync(id);
            if (payMethod == null)
                return NotFound();

            return Ok(payMethod);
        }

        [HttpPost(Name = "CreatePayMethod")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreatePayMethodAsync(Model.PayMethods paymethods)
        {
            await payMethodService.CreatePayMethodAsync(paymethods);
            return CreatedAtRoute("GetPayMethodById", new { id = paymethods.IdPayMethod }, paymethods);
        }

        [HttpPut("{id}", Name = "UpdatePayMethod")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePayMethod(int id, [FromBody] Model.PayMethods paymethods)
        {
            if (id != paymethods.IdPayMethod)
                return BadRequest();

            await payMethodService.UpdatePayMethodAsync(paymethods);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePayMethod")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePayMethod(int id)
        {
            // Método de pago actual por Id
            var existingPayMethod = await payMethodService.GetPayMethodByIdAsync(id);
            if (existingPayMethod == null)
                return NotFound();

            await payMethodService.DeletePayMethodAsync(id);
            return NoContent();
        }
    }
}
