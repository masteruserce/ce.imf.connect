using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class BaseDetailsRepository : IBaseDetailsRepository
    {
        private readonly AppDbContext _context;

        public BaseDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BaseDetails>> GetAllAsync()
        {
            return await _context.BaseDetails.ToListAsync();
        }

        public async Task<BaseDetails?> GetByIdAsync(Guid id)
        {
            return await _context.BaseDetails.FindAsync(id);
        }

        public async Task<BaseDetails?> GetByApplicationNoAsync(string applicationNo)
        {
            return await _context.BaseDetails
                .FirstOrDefaultAsync(b => b.ApplicationNo == applicationNo);
        }

        public async Task<BaseDetails> AddAsync(BaseDetails entity)
        {
            _context.BaseDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<BaseDetails> UpdateAsync(BaseDetails entity)
        {
            _context.BaseDetails.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.BaseDetails.FindAsync(id);
            if (entity == null) return false;

            _context.BaseDetails.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
