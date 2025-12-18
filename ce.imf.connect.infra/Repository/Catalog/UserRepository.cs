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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db) => _db = db;

        public async Task<ClientUser> AddAsync(ClientUser user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<ClientUser?> GetByIdAsync(Guid userId)
        {
            return await _db.Users
                .Include(u => u.Menus)
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<IEnumerable<ClientUser>> GetByClientAsync(Guid clientId)
        {
            return await _db.Users
                .Include(u => u.Menus)
                .Where(u => u.ClientId == clientId && u.Active)
                .ToListAsync();
        }

        public async Task UpdateAsync(ClientUser user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }

        // Soft delete (make inactive)
        public async Task DeleteAsync(Guid userId)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user != null)
            {
                user.Active = false;
                await _db.SaveChangesAsync();
            }
        }

        public async Task<ClientUser?> GetByUserNameAsync(string userName)
        {
            return await _db.Users
                .FirstOrDefaultAsync(u => u.UserName == userName && u.Active);
        }
    }

}
