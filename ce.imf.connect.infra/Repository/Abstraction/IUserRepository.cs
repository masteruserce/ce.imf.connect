using ce.imf.connect.models;
namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IUserRepository
    {
        Task<ClientUser> AddAsync(ClientUser user);
        Task<ClientUser?> GetByIdAsync(Guid userId);
        Task<IEnumerable<ClientUser>> GetByClientAsync(Guid clientId);
        Task UpdateAsync(ClientUser user);
        Task DeleteAsync(Guid userId);
        Task<ClientUser?> GetByUserNameAsync(string userName);
    }
}
