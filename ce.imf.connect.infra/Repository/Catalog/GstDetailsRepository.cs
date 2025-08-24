using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class GstDetailsRepository : IGstDetailsRepository
    {
        private readonly AppDbContext _context;

        public GstDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GstDetails>> GetAllAsync()
        {
            return await _context.GstDetails.ToListAsync();
        }

        public async Task<GstDetails?> GetByIdAsync(Guid id)
        {
            return await _context.GstDetails.FindAsync(id);
        }

        public async Task<GstDetails?> GetByApplicationNoAsync(string applicationNo)
        {
            return await _context.GstDetails
                .FirstOrDefaultAsync(g => g.ApplicationNo == applicationNo);
        }

        public async Task<GstDetails> AddAsync(GstDetails entity)
        {
            _context.GstDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<GstDetails> UpdateAsync(GstDetails entity)
        {
            _context.GstDetails.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.GstDetails.FindAsync(id);
            if (entity == null) return false;

            _context.GstDetails.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
