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
    public class SourcingDetailsRepository : ISourcingDetailsRepository
    {
        private readonly AppDbContext _context;

        public SourcingDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SourcingDetails>> GetAllAsync()
        {
            return await _context.SourcingDetails.ToListAsync();
        }

        public async Task<SourcingDetails?> GetByIdAsync(Guid id)
        {
            return await _context.SourcingDetails.FindAsync(id);
        }

        public async Task<SourcingDetails> AddAsync(SourcingDetails entity)
        {
            _context.SourcingDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SourcingDetails> UpdateAsync(SourcingDetails entity)
        {
            _context.SourcingDetails.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.SourcingDetails.FindAsync(id);
            if (entity == null) return false;

            _context.SourcingDetails.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
