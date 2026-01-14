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
    public class PostCodeRepository : IPostalCodeRepository
    {
        private readonly AppDbContext _db;
        public PostCodeRepository(AppDbContext db) => _db = db;

        public async Task<List<PostalCode>> GetAsync(int pincode)
        {
            return await _db.PostalCode.Where(x => x.PinCode == pincode).ToListAsync();
        }
        public async Task<List<string>> GetSatateAsync(string input)
        {
            return await _db.PostalCode.Where(x => x.StateName.Contains(input))
                                       .Select(s=>s.StateName).Distinct().ToListAsync();
        }
        public async Task<List<string>> GetDistrictAsync(string state, string district)
        {
            return await _db.PostalCode.Where(x => x.StateName == state && x.District.Contains(district))
                                       .Select(s=>s.District).Distinct().ToListAsync();
        }
    }

}
