using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IPlanPremiumRepository
    {
        Task<IEnumerable<PlanPremiumDetails>> GetAllAsync();
        Task<PlanPremiumDetails?> GetByIdAsync(Guid id);
        Task<PlanPremiumDetails> AddAsync(PlanPremiumDetails entity);
        Task<PlanPremiumDetails> UpdateAsync(PlanPremiumDetails entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
