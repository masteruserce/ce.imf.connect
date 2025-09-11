using ce.imf.connect.models;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IFormDataValueRepository
    {
        Task<FormDataValue> AddAsync(FormDataValue entity);
        Task<FormDataValue?> GetByIdAsync(Guid id);
        Task<IEnumerable<FormDataValue>> GetByFormAsync(Guid formId, Guid? clientId);
        Task UpdateAsync(FormDataValue entity);
        Task ActivateAsync(Guid id);
        Task DeactivateAsync(Guid id);
    }

}
