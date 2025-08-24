using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class FiftyBcDetailsRepository : IFiftyBcDetailsRepository
    {
        private readonly AppDbContext _context;

        public FiftyBcDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FiftyBcDetails>> GetAllAsync()
        {
            return await _context.FiftyBcDetails.ToListAsync();
        }

        public async Task<FiftyBcDetails?> GetByIdAsync(Guid id)
        {
            return await _context.FiftyBcDetails.FindAsync(id);
        }

        public async Task<FiftyBcDetails?> GetByApplicationNoAsync(string applicationNo)
        {
            return await _context.FiftyBcDetails
                .FirstOrDefaultAsync(f => f.ApplicationNo == applicationNo);
        }

        public async Task<FiftyBcDetails> AddAsync(FiftyBcDetails entity)
        {
            _context.FiftyBcDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<FiftyBcDetails> UpdateAsync(FiftyBcDetails entity)
        {
            _context.FiftyBcDetails.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.FiftyBcDetails.FindAsync(id);
            if (entity == null) return false;

            _context.FiftyBcDetails.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
