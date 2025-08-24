using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceProductController : ControllerBase
    {
        private readonly IInsuranceProductService _service;

        public InsuranceProductController(IInsuranceProductService service)
        {
            _service = service;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _service.GetByIdAsync(id);
            if (!response.Success) return NotFound(response);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InsuranceProductDto dto)
        {
            var response = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InsuranceProductDto dto)
        {
            var response = await _service.UpdateAsync(dto);
            if (!response.Success) return NotFound(response);
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _service.DeleteAsync(id);
            if (!response.Success) return NotFound(response);
            return Ok(response);
        }
    }
}
