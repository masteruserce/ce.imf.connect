using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GstDetailsController : ControllerBase
    {
        private readonly IGstDetailsService _service;

        public GstDetailsController(IGstDetailsService service)
        {
            _service = service;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ImfResponse<GstDetailsDto>>> GetById(Guid id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpGet("application/{applicationNo}")]
        public async Task<ActionResult<ImfResponse<GstDetailsDto>>> GetByApplicationNo(string applicationNo)
            => Ok(await _service.GetByApplicationNoAsync(applicationNo));

        [HttpPost]
        public async Task<ActionResult<ImfResponse<GstDetailsDto>>> Create([FromBody] GstDetailsDto dto)
            => Ok(await _service.AddAsync(dto));

        [HttpPut]
        public async Task<ActionResult<ImfResponse<GstDetailsDto>>> Update([FromBody] GstDetailsDto dto)
            => Ok(await _service.UpdateAsync(dto));

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ImfResponse<bool>>> Delete(Guid id)
            => Ok(await _service.DeleteAsync(id));
    }
}
