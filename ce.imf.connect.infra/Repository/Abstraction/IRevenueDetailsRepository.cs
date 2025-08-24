using ce.imf.connect.models;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IRevenueDetailsRepository
    {
        Task<IEnumerable<RevenueDetails>> GetAllAsync();
        Task<RevenueDetails?> GetByIdAsync(Guid id);
        Task<RevenueDetails?> GetByApplicationNoAsync(string applicationNo);
        Task<RevenueDetails> AddAsync(RevenueDetails entity);
        Task<RevenueDetails> UpdateAsync(RevenueDetails entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
