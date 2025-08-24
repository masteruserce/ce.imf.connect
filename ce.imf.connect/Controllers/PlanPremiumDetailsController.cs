using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanPremiumDetailsController : ControllerBase
    {
        private readonly IPlanPremiumService _service;

        public PlanPremiumDetailsController(IPlanPremiumService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ImfResponse<IEnumerable<PlanPremiumDetailsDto>>>> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ImfResponse<PlanPremiumDetailsDto?>>> Get(Guid id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<ActionResult<ImfResponse<PlanPremiumDetailsDto>>> Create([FromBody] PlanPremiumDetailsDto dto)
            => Ok(await _service.AddAsync(dto));

        [HttpPut("{id}")]
        public async Task<ActionResult<ImfResponse<PlanPremiumDetailsDto?>>> Update(Guid id, [FromBody] PlanPremiumDetailsDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(new ImfResponse<PlanPremiumDetailsDto?>(new List<ImfErrors>
            {
                new ImfErrors { Code = "ID_MISMATCH", Details = "Id in route does not match Id in body" }
            }, "Validation failed."));
            }

            return Ok(await _service.UpdateAsync(dto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ImfResponse<bool>>> Delete(Guid id)
            => Ok(await _service.DeleteAsync(id));
    }

}
