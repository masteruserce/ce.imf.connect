using ce.imf.connect.models;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IPcDetailsRepository
    {
        Task<IEnumerable<PcDetails>> GetAllAsync();
        Task<PcDetails?> GetByIdAsync(Guid id);
        Task<PcDetails?> GetByApplicationNoAsync(string applicationNo);
        Task<PcDetails> AddAsync(PcDetails entity);
        Task<PcDetails> UpdateAsync(PcDetails entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
