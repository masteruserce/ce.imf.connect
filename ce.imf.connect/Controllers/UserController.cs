using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service) => _service = service;

        [HttpPost("create")]
        public async Task<ActionResult<ImfResponse<UserDto>>> Create(CreateUserRequest request) =>
            Ok(await _service.CreateUserAsync(request));

        [HttpPut("update")]
        public async Task<ActionResult<ImfResponse<UserDto>>> Update(UserDto dto) =>
            Ok(await _service.UpdateUserAsync(dto));

        [HttpPost("{userId}/change-password")]
        public async Task<ActionResult<ImfResponse<bool>>> ChangePassword(Guid userId, [FromBody] string newPassword) =>
            Ok(await _service.ChangePasswordAsync(userId, newPassword));

        [HttpGet("by-client/{clientId}")]
        public async Task<ActionResult<ImfResponse<IEnumerable<UserDto>>>> GetByClient(Guid clientId) =>
            Ok(await _service.GetUsersByClientAsync(clientId));
    }

}
