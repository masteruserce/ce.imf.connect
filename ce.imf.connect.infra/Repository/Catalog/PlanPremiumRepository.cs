using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class PlanPremiumRepository : IPlanPremiumRepository
    {
        private readonly AppDbContext _context;

        public PlanPremiumRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlanPremiumDetails>> GetAllAsync()
            => await _context.PlanPremiumDetails.ToListAsync();

        public async Task<PlanPremiumDetails?> GetByIdAsync(Guid id)
            => await _context.PlanPremiumDetails.FindAsync(id);

        public async Task<PlanPremiumDetails> AddAsync(PlanPremiumDetails entity)
        {
            _context.PlanPremiumDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PlanPremiumDetails> UpdateAsync(PlanPremiumDetails entity)
        {
            var existing = await _context.PlanPremiumDetails.FindAsync(entity.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.PlanPremiumDetails.FindAsync(id);
            if (entity == null) return false;

            _context.PlanPremiumDetails.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }

}
