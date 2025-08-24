using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PcDetailsController : ControllerBase
    {
        private readonly IPcDetailsService _service;

        public PcDetailsController(IPcDetailsService service)
        {
            _service = service;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ImfResponse<PcDetailsDto>>> GetById(Guid id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpGet("application/{applicationNo}")]
        public async Task<ActionResult<ImfResponse<PcDetailsDto>>> GetByApplicationNo(string applicationNo)
            => Ok(await _service.GetByApplicationNoAsync(applicationNo));

        [HttpPost]
        public async Task<ActionResult<ImfResponse<PcDetailsDto>>> Create([FromBody] PcDetailsDto dto)
            => Ok(await _service.AddAsync(dto));

        [HttpPut]
        public async Task<ActionResult<ImfResponse<PcDetailsDto>>> Update([FromBody] PcDetailsDto dto)
            => Ok(await _service.UpdateAsync(dto));

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ImfResponse<bool>>> Delete(Guid id)
            => Ok(await _service.DeleteAsync(id));
    }
}
