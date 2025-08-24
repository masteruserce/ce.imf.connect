using ce.imf.connect.models;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IInsuranceProductRepository
    {
        Task<InsuranceProduct?> GetByIdAsync(Guid id);
        Task<IEnumerable<InsuranceProduct>> GetAllAsync();
        Task<InsuranceProduct> AddAsync(InsuranceProduct dto);
        Task<InsuranceProduct?> UpdateAsync(InsuranceProduct dto);
        Task<bool> DeleteAsync(Guid id);
    }
}