using ce.imf.connect.models;
using ce.imf.connect.infra.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class InsuranceProductRepository : IInsuranceProductRepository
    {
        private readonly AppDbContext _context;

        public InsuranceProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<InsuranceProduct?> GetByIdAsync(Guid id)
        {
            var entity = await _context.InsuranceProducts.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<IEnumerable<InsuranceProduct>> GetAllAsync()
        {
            var entities = await _context.InsuranceProducts.ToListAsync();
            return entities;
        }

        public async Task<InsuranceProduct> AddAsync(InsuranceProduct entity)
        {
            _context.InsuranceProducts.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<InsuranceProduct?> UpdateAsync(InsuranceProduct entity)
        {
            _context.InsuranceProducts.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.InsuranceProducts.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;

            _context.InsuranceProducts.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
