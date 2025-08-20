using ce.imf.connect.models;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface ISourcingDetailsRepository
    {
        public Task<IEnumerable<SourcingDetails>> GetAllAsync();
        public Task<SourcingDetails?> GetByIdAsync(Guid id);
        public Task<SourcingDetails> AddAsync(SourcingDetails entity);
        public Task<SourcingDetails> UpdateAsync(SourcingDetails entity);
        public Task<bool> DeleteAsync(Guid id);
    }

}
