using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class InsuranceCategoryRepository : IInsuranceCategoryRepository
    {
        private readonly AppDbContext _context;

        public InsuranceCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InsuranceCategory>> GetAllAsync()
        {
            return await _context.InsuranceCategories.ToListAsync();
        }

        public async Task<InsuranceCategory?> GetByIdAsync(Guid id)
        {
            return await _context.InsuranceCategories.FindAsync(id);
        }

        public async Task<InsuranceCategory> AddAsync(InsuranceCategory entity)
        {
            _context.InsuranceCategories.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<InsuranceCategory> UpdateAsync(InsuranceCategory entity)
        {
            _context.InsuranceCategories.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.InsuranceCategories.FindAsync(id);
            if (entity == null) return false;
            _context.InsuranceCategories.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<InsuranceCategory>> GetByType(string insuranceType)
        {
            return await _context.InsuranceCategories
                                 .Where(c => c.InsuranceType!.Equals(insuranceType, StringComparison.OrdinalIgnoreCase))
                                 .ToListAsync();
        }
    }
}
