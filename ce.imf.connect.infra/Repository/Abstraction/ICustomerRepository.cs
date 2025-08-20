using ce.imf.connect.models;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(Guid id);
        Task<Customer> AddAsync(Customer entity);
        Task<Customer> UpdateAsync(Customer entity);
        Task<bool> DeleteAsync(Guid id);
    }

}
