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
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _db;

        public ClientRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Clients>> GetAllAsync() => await _db.Clients.ToListAsync();

        public async Task<Clients?> GetByIdAsync(Guid clientId) =>
            await _db.Clients.FirstOrDefaultAsync(c => c.ClientId == clientId);

        public async Task<Clients> AddAsync(Clients client)
        {
            _db.Clients.Add(client);
            await _db.SaveChangesAsync();
            return client;
        }

        public async Task<Clients> UpdateAsync(Clients client)
        {
            _db.Clients.Update(client);
            await _db.SaveChangesAsync();
            return client;
        }

        public async Task DeleteAsync(Guid clientId)
        {
            var client = await GetByIdAsync(clientId);
            if (client != null)
            {
                _db.Clients.Remove(client);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Clients> DeativateAsync(Guid clientId)
        {
            var client = await _db.Clients.FirstOrDefaultAsync(c => c.ClientId == clientId);
            if (client != null)
            {
                client.IsActive = false;
                _db.Clients.Update(client);
               await _db.SaveChangesAsync();
            }
            return client;
        }

        public async Task<Clients> ActivateAsync(Guid clientId)
        {
            var client = await _db.Clients.FirstOrDefaultAsync(c => c.ClientId == clientId);
            if (client != null)
            {
                client.IsActive = true;
                _db.Clients.Update(client);
                await _db.SaveChangesAsync();
            }
            return client;
        }

        public async Task<bool> IfUserNameExists(string userName)
        {
            var result = await _db.Clients.FirstOrDefaultAsync(x => x.UserName == userName);
            return null != result;
        }

        public async Task<Clients?> GetByUsernameAsync(string userName)
        {
            return await _db.Clients.FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
