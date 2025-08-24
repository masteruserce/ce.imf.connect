using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class FinalDetailsRepository : IFinalDetailsRepository
    {
        private readonly AppDbContext _context;

        public FinalDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FinalDetails>> GetAllAsync()
        {
            return await _context.FinalDetails.ToListAsync();
        }

        public async Task<FinalDetails?> GetByIdAsync(Guid id)
        {
            return await _context.FinalDetails.FindAsync(id);
        }

        public async Task<FinalDetails?> GetByApplicationNoAsync(string applicationNo)
        {
            return await _context.FinalDetails
                .FirstOrDefaultAsync(f => f.ApplicationNo == applicationNo);
        }

        public async Task<FinalDetails> AddAsync(FinalDetails entity)
        {
            _context.FinalDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<FinalDetails> UpdateAsync(FinalDetails entity)
        {
            _context.FinalDetails.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.FinalDetails.FindAsync(id);
            if (entity == null) return false;

            _context.FinalDetails.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
