using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.DTOs;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormDataValuesController : ControllerBase
    {
        private readonly IFormDataValueService _service;
        public FormDataValuesController(IFormDataValueService service) => _service = service;

        [HttpPost("save")]
        public async Task<ActionResult<ImfResponse<FormDataValueDto>>> Save([FromBody] FormDataValueDto dto)
            => Ok(await _service.SaveAsync(dto));

        [HttpPut("update")]
        public async Task<ActionResult<ImfResponse<FormDataValueDto>>> Update([FromBody] FormDataValueDto dto)
            => Ok(await _service.UpdateAsync(dto));

        [HttpPost("{id}/activate")]
        public async Task<ActionResult<ImfResponse<bool>>> Activate(Guid id)
            => Ok(await _service.ActivateAsync(id));

        [HttpPost("{id}/deactivate")]
        public async Task<ActionResult<ImfResponse<bool>>> Deactivate(Guid id)
            => Ok(await _service.DeactivateAsync(id));

        [HttpGet("{formId}/{clientId?}")]
        public async Task<ActionResult<ImfResponse<IEnumerable<FormDataValueDto>>>> GetByForm(Guid formId, Guid? clientId)
            => Ok(await _service.GetByFormAsync(formId, clientId));
    }

}
