using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.infra.Repository.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterDataController : ControllerBase
    {
        private readonly IPostalCodeService _service;
        public MasterDataController(IPostalCodeService service) { _service = service;}

        [HttpGet("{postalCode:int}")]
        public async Task<IActionResult> Get(int postalCode)
        {
            var res = await _service.GetAsync(postalCode);
            if (res ==null) return BadRequest(res);
            return Ok(res);
        }

        [HttpGet("{input}")]
        public async Task<IActionResult> Get(string input)
        {
            var res = await _service.GetSatateAsync(input);
            if (res == null) return BadRequest(res);
            return Ok(res);
        }

        [HttpGet("{state}/{district}")]
        public async Task<IActionResult> Get(string state, string district)
        {
            var res = await _service.GetDistrictAsync(state, district);
            if (res == null) return BadRequest(res);
            return Ok(res);
        }
    }
}
