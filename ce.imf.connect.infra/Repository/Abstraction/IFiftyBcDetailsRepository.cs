using ce.imf.connect.models;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IFiftyBcDetailsRepository
    {
        Task<IEnumerable<FiftyBcDetails>> GetAllAsync();
        Task<FiftyBcDetails?> GetByIdAsync(Guid id);
        Task<FiftyBcDetails?> GetByApplicationNoAsync(string applicationNo);
        Task<FiftyBcDetails> AddAsync(FiftyBcDetails entity);
        Task<FiftyBcDetails> UpdateAsync(FiftyBcDetails entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
