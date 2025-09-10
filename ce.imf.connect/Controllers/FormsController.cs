using ce.imf.connect.comon.DTOs;
using ce.imf.connect.infra.Repository.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormsController : ControllerBase
    {
        private readonly IFormService _service;
        public FormsController(IFormService service) { _service = service; }

        [HttpPost("import")]
        public async Task<IActionResult> Import([FromBody] ImportFieldsRequest request)
        {
            var res = await _service.ImportFormAsync(request);
            if (!res.Success) return BadRequest(res);
            return Ok(res);
        }

        [HttpGet("{clientId:guid}/{formName}")]
        public async Task<IActionResult> GetByClientAndForm(Guid clientId, string formName)
        {
            var res = await _service.GetFormAsync(clientId, formName);
            if (!res.Success) return BadRequest(res);
            return Ok(res);
        }
    }
}
