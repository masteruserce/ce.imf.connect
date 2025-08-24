using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class PolicyLoginDetailsRepository : IPolicyLoginDetailsRepository
    {
        private readonly AppDbContext _context;

        public PolicyLoginDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PolicyLoginDetails>> GetAllAsync() =>
            await _context.PolicyLoginDetails.ToListAsync();

        public async Task<PolicyLoginDetails?> GetByIdAsync(Guid id) =>
            await _context.PolicyLoginDetails.FindAsync(id);

        public async Task<PolicyLoginDetails> AddAsync(PolicyLoginDetails entity)
        {
            _context.PolicyLoginDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PolicyLoginDetails?> UpdateAsync(PolicyLoginDetails entity)
        {
            var existing = await _context.PolicyLoginDetails.FindAsync(entity.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.PolicyLoginDetails.FindAsync(id);
            if (entity == null) return false;

            _context.PolicyLoginDetails.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
