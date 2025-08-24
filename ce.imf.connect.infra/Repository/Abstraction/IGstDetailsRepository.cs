using ce.imf.connect.models;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IGstDetailsRepository
    {
        Task<IEnumerable<GstDetails>> GetAllAsync();
        Task<GstDetails?> GetByIdAsync(Guid id);
        Task<GstDetails?> GetByApplicationNoAsync(string applicationNo);
        Task<GstDetails> AddAsync(GstDetails entity);
        Task<GstDetails> UpdateAsync(GstDetails entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
