using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models.InsuranceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class PayoutDetailsRepository : IPayoutDetailsRepository
    {
        private readonly AppDbContext _context;

        public PayoutDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PayoutDetails>> GetAllAsync()
        {
            return await _context.PayoutDetails.ToListAsync();
        }

        public async Task<PayoutDetails?> GetByIdAsync(Guid id)
        {
            return await _context.PayoutDetails.FindAsync(id);
        }

        public async Task<PayoutDetails?> GetByApplicationNoAsync(string applicationNo)
        {
            return await _context.PayoutDetails
                .FirstOrDefaultAsync(p => p.ApplicationNo == applicationNo);
        }

        public async Task<PayoutDetails> AddAsync(PayoutDetails entity)
        {
            _context.PayoutDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PayoutDetails> UpdateAsync(PayoutDetails entity)
        {
            _context.PayoutDetails.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.PayoutDetails.FindAsync(id);
            if (entity == null) return false;

            _context.PayoutDetails.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
