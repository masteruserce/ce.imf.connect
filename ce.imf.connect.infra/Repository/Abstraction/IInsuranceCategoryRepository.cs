using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IInsuranceCategoryRepository
    {
        Task<IEnumerable<InsuranceCategory>> GetByType(string insuranceType);
        Task<IEnumerable<InsuranceCategory>> GetAllAsync();
        Task<InsuranceCategory?> GetByIdAsync(Guid id);
        Task<InsuranceCategory> AddAsync(InsuranceCategory entity);
        Task<InsuranceCategory> UpdateAsync(InsuranceCategory entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
