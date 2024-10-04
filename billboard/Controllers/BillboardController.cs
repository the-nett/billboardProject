using billboard.Model;
using billboard.Repositories; // Importar el repositorio
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillboardsController : ControllerBase
    {
        private readonly IBillboardRepository _billboardRepository;

        // Inyectar el repositorio a través del constructor
        public BillboardsController(IBillboardRepository billboardRepository)
        {
            _billboardRepository = billboardRepository;
        }

        // GET: api/billboards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Billboard>>> GetBillboards()
        {
            var billboards = await _billboardRepository.GetAllBillboardsAsync();
            return Ok(billboards);
        }

        // GET: api/billboards/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Billboard>> GetBillboard(int id)
        {
            var billboard = await _billboardRepository.GetBillboardByIdAsync(id);
            if (billboard == null)
            {
                return NotFound();
            }
            return Ok(billboard);
        }

        // POST: api/billboards
        [HttpPost]
        public async Task<ActionResult<Billboard>> PostBillboard(Billboard billboard)
        {
            await _billboardRepository.CreateBillboardAsync(billboard);
            return CreatedAtAction(nameof(GetBillboard), new { id = billboard.IdBillboard }, billboard);
        }

        // PUT: api/billboards/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillboard(int id, Billboard billboard)
        {
            if (id != billboard.IdBillboard)
            {
                return BadRequest();
            }

            await _billboardRepository.UpdateBillboardAsync(billboard);
            return NoContent();
        }

        // DELETE: api/billboards/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillboard(int id)
        {
            await _billboardRepository.SoftDeleteBillboardAsync(id);
            return NoContent();
        }
    }
}
