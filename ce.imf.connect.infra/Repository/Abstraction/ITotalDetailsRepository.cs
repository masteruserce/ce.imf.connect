using ce.imf.connect.models;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface ITotalDetailsRepository
    {
        Task<IEnumerable<TotalDetails>> GetAllAsync();
        Task<TotalDetails?> GetByIdAsync(Guid id);
        Task<TotalDetails?> GetByApplicationNoAsync(string applicationNo);
        Task<TotalDetails> AddAsync(TotalDetails entity);
        Task<TotalDetails> UpdateAsync(TotalDetails entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
