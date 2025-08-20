using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class SourcingController : ControllerBase
    {
        readonly ISourcingDetailsService _service;
        public SourcingController(ISourcingDetailsService service)
        {
            _service = service;
        }

        // GET: api/SourcingDetails/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ImfResponse<SourcingDetailsDto>>> GetById(Guid id)
        {
            var response = await _service.GetByIdAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        // GET: api/SourcingDetails
        [HttpGet]
        public async Task<ActionResult<ImfResponse<IEnumerable<SourcingDetailsDto>>>> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        // POST: api/SourcingDetails
        [HttpPost]
        public async Task<ActionResult<ImfResponse<SourcingDetailsDto>>> Create([FromBody] SourcingDetailsDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ImfResponse<SourcingDetailsDto>(
                    new List<ImfErrors>
                    {
                    new ImfErrors { Code = "VALIDATION_ERROR", Details = "Invalid model state." }
                    },
                    "Validation failed"
                ));
            }

            var response = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response);
        }

        // PUT: api/SourcingDetails/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ImfResponse<SourcingDetailsDto>>> Update(Guid id, [FromBody] SourcingDetailsDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ImfResponse<SourcingDetailsDto>(
                    new List<ImfErrors>
                    {
                    new ImfErrors { Code = "VALIDATION_ERROR", Details = "Invalid model state." }
                    },
                    "Validation failed"
                ));
            }

            dto.Id = id;
            var response = await _service.UpdateAsync(dto);
            return response.Success ? Ok(response) : NotFound(response);
        }

        // DELETE: api/SourcingDetails/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ImfResponse<bool>>> Delete(Guid id)
        {
            var response = await _service.DeleteAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}
