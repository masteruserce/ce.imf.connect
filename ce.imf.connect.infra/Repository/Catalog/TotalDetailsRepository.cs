using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class TotalDetailsRepository : ITotalDetailsRepository
    {
        private readonly AppDbContext _context;

        public TotalDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TotalDetails>> GetAllAsync()
        {
            return await _context.TotalDetails.ToListAsync();
        }

        public async Task<TotalDetails?> GetByIdAsync(Guid id)
        {
            return await _context.TotalDetails.FindAsync(id);
        }

        public async Task<TotalDetails?> GetByApplicationNoAsync(string applicationNo)
        {
            return await _context.TotalDetails
                .FirstOrDefaultAsync(t => t.ApplicationNo == applicationNo);
        }

        public async Task<TotalDetails> AddAsync(TotalDetails entity)
        {
            _context.TotalDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TotalDetails> UpdateAsync(TotalDetails entity)
        {
            _context.TotalDetails.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.TotalDetails.FindAsync(id);
            if (entity == null) return false;

            _context.TotalDetails.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
