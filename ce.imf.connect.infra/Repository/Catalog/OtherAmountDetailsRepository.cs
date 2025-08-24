using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class OtherAmountDetailsRepository : IOtherAmountDetailsRepository
    {
        private readonly AppDbContext _context;

        public OtherAmountDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OtherAmountDetails>> GetAllAsync()
        {
            return await _context.OtherAmountDetails.ToListAsync();
        }

        public async Task<OtherAmountDetails?> GetByIdAsync(Guid id)
        {
            return await _context.OtherAmountDetails.FindAsync(id);
        }

        public async Task<OtherAmountDetails?> GetByApplicationNoAsync(string applicationNo)
        {
            return await _context.OtherAmountDetails
                .FirstOrDefaultAsync(o => o.ApplicationNo == applicationNo);
        }

        public async Task<OtherAmountDetails> AddAsync(OtherAmountDetails entity)
        {
            _context.OtherAmountDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<OtherAmountDetails> UpdateAsync(OtherAmountDetails entity)
        {
            _context.OtherAmountDetails.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.OtherAmountDetails.FindAsync(id);
            if (entity == null) return false;

            _context.OtherAmountDetails.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
