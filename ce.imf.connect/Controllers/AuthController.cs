using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.application.Service.Catalog;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ImfResponse<AuthResponse>>> Login([FromBody] AuthRequest request)
        {
            var result = await _authService.AuthenticateAsync(request);
            if (!result.Success)
                return Unauthorized(result);

            return Ok(result);
        }
    }
}
