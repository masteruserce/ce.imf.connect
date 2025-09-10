using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ImfResponse<List<ClientDto>>>> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ImfResponse<ClientDto>>> Get(Guid id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<ActionResult<ImfResponse<ClientDto>>> Create(ClientDto dto)
            => Ok(await _service.AddAsync(dto));

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ImfResponse<ClientDto>>> Update(Guid id, ClientDto dto)
        {
            dto.ClientId = id;
            return Ok(await _service.UpdateAsync(dto));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ImfResponse<string>>> Delete(Guid id)
        {
            return Ok(await _service.DeleteAsync(id));
        }

        [HttpPut("activate/{id:guid}")]
        public async Task<ActionResult<ImfResponse<ClientDto>>> Activate(Guid id)
        {
            return Ok(await _service.ActivateAsync(id));
        }

        [HttpPut("deactivate/{id:guid}")]
        public async Task<ActionResult<ImfResponse<ClientDto>>> DeActivate(Guid id)
        {
            return Ok(await _service.DeActivateAsync(id));
        }
    }
}
