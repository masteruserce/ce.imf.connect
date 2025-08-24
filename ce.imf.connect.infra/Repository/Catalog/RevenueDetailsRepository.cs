using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class RevenueDetailsRepository : IRevenueDetailsRepository
    {
        private readonly AppDbContext _context;

        public RevenueDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RevenueDetails>> GetAllAsync()
        {
            return await _context.RevenueDetails.ToListAsync();
        }

        public async Task<RevenueDetails?> GetByIdAsync(Guid id)
        {
            return await _context.RevenueDetails.FindAsync(id);
        }

        public async Task<RevenueDetails?> GetByApplicationNoAsync(string applicationNo)
        {
            return await _context.RevenueDetails
                .FirstOrDefaultAsync(r => r.ApplicationNo == applicationNo);
        }

        public async Task<RevenueDetails> AddAsync(RevenueDetails entity)
        {
            _context.RevenueDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<RevenueDetails> UpdateAsync(RevenueDetails entity)
        {
            _context.RevenueDetails.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.RevenueDetails.FindAsync(id);
            if (entity == null) return false;

            _context.RevenueDetails.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
