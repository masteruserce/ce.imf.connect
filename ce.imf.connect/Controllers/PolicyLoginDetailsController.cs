using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolicyLoginDetailsController : ControllerBase
    {
        private readonly IPolicyLoginDetailsService _service;

        public PolicyLoginDetailsController(IPolicyLoginDetailsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ImfResponse<IEnumerable<PolicyLoginDetailsDto>>>> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ImfResponse<PolicyLoginDetailsDto?>>> Get(Guid id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<ActionResult<ImfResponse<PolicyLoginDetailsDto>>> Create([FromBody] PolicyLoginDetailsDto dto)
            => Ok(await _service.AddAsync(dto));

        [HttpPut("{id}")]
        public async Task<ActionResult<ImfResponse<PolicyLoginDetailsDto?>>> Update(Guid id, [FromBody] PolicyLoginDetailsDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new ImfResponse<PolicyLoginDetailsDto?>(new List<ImfErrors> {
                new ImfErrors { Code="ID_MISMATCH", Details="Id in route and body do not match" }
            }, "Validation failed."));
            return Ok(await _service.UpdateAsync(dto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ImfResponse<bool>>> Delete(Guid id)
            => Ok(await _service.DeleteAsync(id));
    }

}
