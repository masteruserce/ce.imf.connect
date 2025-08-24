using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class PcDetailsRepository : IPcDetailsRepository
    {
        private readonly AppDbContext _context;

        public PcDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PcDetails>> GetAllAsync()
        {
            return await _context.PcDetails.ToListAsync();
        }

        public async Task<PcDetails?> GetByIdAsync(Guid id)
        {
            return await _context.PcDetails.FindAsync(id);
        }

        public async Task<PcDetails?> GetByApplicationNoAsync(string applicationNo)
        {
            return await _context.PcDetails
                .FirstOrDefaultAsync(p => p.ApplicationNo == applicationNo);
        }

        public async Task<PcDetails> AddAsync(PcDetails entity)
        {
            _context.PcDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PcDetails> UpdateAsync(PcDetails entity)
        {
            _context.PcDetails.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.PcDetails.FindAsync(id);
            if (entity == null) return false;

            _context.PcDetails.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
