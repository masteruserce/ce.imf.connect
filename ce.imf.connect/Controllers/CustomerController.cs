using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/leads
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        // GET: api/leads/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return Ok(customer);
        }

        // POST: api/leads
        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto customerDto)
        {
           var result = await  _customerService.CreateAsync(customerDto);
            if (result.Errors != null && result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }
            return CreatedAtAction(nameof(Get), new { id = customerDto.Id }, result.Data);
        }

        // PUT: api/leads/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(CustomerDto updatedCustomer)
        {
         var result = await _customerService.UpdateAsync(updatedCustomer);
            if (result.Errors != null && result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }

        // DELETE: api/leads/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _customerService.DeleteAsync(id);
            if (result.Errors != null && result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }
            if (result.Data)
            {
                return NoContent(); // 204 No Content
            }
            return NotFound(new ImfErrors { Code = "NOT_FOUND", Details = $"Lead with ID {id} not found." });
        }
    }
}
