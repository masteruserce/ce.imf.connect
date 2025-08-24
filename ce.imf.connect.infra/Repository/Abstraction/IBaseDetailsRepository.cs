using ce.imf.connect.models;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IBaseDetailsRepository
    {
        Task<IEnumerable<BaseDetails>> GetAllAsync();
        Task<BaseDetails?> GetByIdAsync(Guid id);
        Task<BaseDetails?> GetByApplicationNoAsync(string applicationNo);
        Task<BaseDetails> AddAsync(BaseDetails entity);
        Task<BaseDetails> UpdateAsync(BaseDetails entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
