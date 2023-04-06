using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnocaProject.Business.Abstract;
using EnocaProject.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EnocaProject.API.Controllers
{
    [Route("api/[controller]")]
    public class CarrierConfigurationController : Controller
    {
        private readonly ICarrierConfigurationService _carrierConfigurationService;

        public CarrierConfigurationController(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }

        [HttpGet]
        public ActionResult<List<CarrierConfiguration>> GetAll()
        {
            var carrierConfigurations = _carrierConfigurationService.GetAll();
            return Ok(carrierConfigurations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarrierConfiguration>> GetById(int id)
        {
            var carrierConfiguration = await _carrierConfigurationService.GetById(id);
            if (carrierConfiguration == null)
            {
                return NotFound();
            }
            return Ok(carrierConfiguration);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CarrierConfiguration carrierConfiguration)
        {
            await _carrierConfigurationService.AddAsync(carrierConfiguration);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CarrierConfiguration carrierConfiguration)
        {
            if (id != carrierConfiguration.Id)
            {
                return BadRequest();
            }

            await _carrierConfigurationService.Update(carrierConfiguration);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var carrierConfiguration = await _carrierConfigurationService.GetById(id);
            if (carrierConfiguration == null)
            {
                return NotFound();
            }

            await _carrierConfigurationService.Delete(id);
            return Ok();
        }
    }
}

