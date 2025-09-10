using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceCategoryController : ControllerBase
    {
        private readonly IInsuranceCategoryService _service;

        public InsuranceCategoryController(IInsuranceCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _service.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InsuranceCategoryDto dto)
        {
            var response = await _service.AddAsync(dto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InsuranceCategoryDto dto)
        {
            var response = await _service.UpdateAsync(dto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
        [HttpGet("{type}")]
        public async Task<IActionResult> Get(string type)
        {
            var response = await _service.GetByType(type);
            return Ok(response);
        }
    }
}
