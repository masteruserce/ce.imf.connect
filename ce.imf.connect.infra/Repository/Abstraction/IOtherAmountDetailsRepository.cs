using ce.imf.connect.models;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IOtherAmountDetailsRepository
    {
        Task<IEnumerable<OtherAmountDetails>> GetAllAsync();
        Task<OtherAmountDetails?> GetByIdAsync(Guid id);
        Task<OtherAmountDetails?> GetByApplicationNoAsync(string applicationNo);
        Task<OtherAmountDetails> AddAsync(OtherAmountDetails entity);
        Task<OtherAmountDetails> UpdateAsync(OtherAmountDetails entity);
        Task<bool> DeleteAsync(Guid id);
    }
}