using ce.imf.connect.infra;
using ce.imf.connect.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InsuranceProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var lead = await _context.InsuranceProducts.FindAsync(id);
            return lead == null ? NotFound() : Ok(lead);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.InsuranceProducts.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(InsuranceProduct product)
        {
            _context.InsuranceProducts.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);
        }

        // PUT: api/insuranceProduct/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, InsuranceProduct insuranceProduct)
        {
            var existingInsuranceProduct = await _context.InsuranceProducts.FindAsync(id);
            if (existingInsuranceProduct == null) return NotFound();

            // Update insurance Product properties
            existingInsuranceProduct.Term = insuranceProduct.Term;
            existingInsuranceProduct.PaymentTerm = insuranceProduct.PaymentTerm;
            existingInsuranceProduct.PaymentMode = insuranceProduct.PaymentMode;
            existingInsuranceProduct.Name = insuranceProduct.Name;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/insuranceProduct/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingInsuranceProduct = await _context.InsuranceProducts.FindAsync(id);
            if (existingInsuranceProduct == null) return NotFound();

            // Set insurance Product InActive
            existingInsuranceProduct.IsActive= false;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
