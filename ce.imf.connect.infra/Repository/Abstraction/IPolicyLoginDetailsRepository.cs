using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IPolicyLoginDetailsRepository
    {
        Task<IEnumerable<PolicyLoginDetails>> GetAllAsync();
        Task<PolicyLoginDetails?> GetByIdAsync(Guid id);
        Task<PolicyLoginDetails> AddAsync(PolicyLoginDetails entity);
        Task<PolicyLoginDetails?> UpdateAsync(PolicyLoginDetails entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
