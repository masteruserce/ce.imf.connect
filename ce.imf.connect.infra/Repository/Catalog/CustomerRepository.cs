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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customer.FindAsync(id);
        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            _context.Customer.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Customer> UpdateAsync(Customer entity)
        {
            _context.Customer.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Customer.FindAsync(id);
            if (entity == null) return false;

            _context.Customer.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }

}
