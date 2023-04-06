using EnocaProject.Business.Abstract;
using EnocaProject.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnocaProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrierController : ControllerBase
    {
        private readonly ICarrierService _carrierService;

        public CarrierController(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        [HttpGet]
        public ActionResult<List<Carrier>> GetAll()
        {
            var carriers = _carrierService.GetAll();
            return Ok(carriers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carrier>> GetById(int id)
        {
            var carrier = await _carrierService.GetById(id);
            if (carrier == null)
            {
                return NotFound();
            }
            return Ok(carrier);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Carrier carrier)
        {
            await _carrierService.AddAsync(carrier);
            return Ok("Kargo başarıyla eklendi.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Carrier carrier)
        {
            if (id != carrier.Id)
            {
                return BadRequest("Geçersiz istek");
            }

            await _carrierService.Update(carrier);
            return Ok("Kargo başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var carrier = await _carrierService.GetById(id);
            if (carrier == null)
            {
                return NotFound("Kargo bulunamadı.");
            }

            await _carrierService.Delete(id);
            return Ok("Kargo başarıyla silindi.");
        }
    }
}

