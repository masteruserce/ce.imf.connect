using ce.imf.connect.models;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IFinalDetailsRepository
    {
        Task<IEnumerable<FinalDetails>> GetAllAsync();
        Task<FinalDetails?> GetByIdAsync(Guid id);
        Task<FinalDetails?> GetByApplicationNoAsync(string applicationNo);
        Task<FinalDetails> AddAsync(FinalDetails entity);
        Task<FinalDetails> UpdateAsync(FinalDetails entity);
        Task<bool> DeleteAsync(Guid id);
    }
}