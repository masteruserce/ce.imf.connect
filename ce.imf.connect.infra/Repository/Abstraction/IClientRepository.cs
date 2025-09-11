using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IClientRepository
    {
        Task<List<Clients>> GetAllAsync();
        Task<Clients?> GetByIdAsync(Guid clientId);
        Task<Clients> AddAsync(Clients client);
        Task<Clients> UpdateAsync(Clients client);
        Task<Clients> DeativateAsync(Guid clientId);
        Task<Clients> ActivateAsync(Guid clientId);
        Task DeleteAsync(Guid clientId);
        Task<bool> IfUserNameExists(string userName);
        Task<Clients?> GetByUsernameAsync(string userName);
    }
}
