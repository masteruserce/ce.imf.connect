using ce.imf.connect.models.InsuranceApp.Models;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IPayoutDetailsRepository
    {
        Task<IEnumerable<PayoutDetails>> GetAllAsync();
        Task<PayoutDetails?> GetByIdAsync(Guid id);
        Task<PayoutDetails?> GetByApplicationNoAsync(string applicationNo);
        Task<PayoutDetails> AddAsync(PayoutDetails entity);
        Task<PayoutDetails> UpdateAsync(PayoutDetails entity);
        Task<bool> DeleteAsync(Guid id);
    }
}