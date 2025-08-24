using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseDetailsController : ControllerBase
    {
        private readonly IBaseDetailsService _service;

        public BaseDetailsController(IBaseDetailsService service)
        {
            _service = service;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ImfResponse<BaseDetailsDto>>> GetById(Guid id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpGet("application/{applicationNo}")]
        public async Task<ActionResult<ImfResponse<BaseDetailsDto>>> GetByApplicationNo(string applicationNo)
            => Ok(await _service.GetByApplicationNoAsync(applicationNo));

        [HttpPost]
        public async Task<ActionResult<ImfResponse<BaseDetailsDto>>> Create([FromBody] BaseDetailsDto dto)
            => Ok(await _service.AddAsync(dto));

        [HttpPut]
        public async Task<ActionResult<ImfResponse<BaseDetailsDto>>> Update([FromBody] BaseDetailsDto dto)
            => Ok(await _service.UpdateAsync(dto));

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ImfResponse<bool>>> Delete(Guid id)
            => Ok(await _service.DeleteAsync(id));
    }
}
