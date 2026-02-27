using ce.imf.connect.common.DTOs;
using ce.imf.connect.comon.DTOs;
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
        Task<List<FormDataValue>> AddRangeAsync(List<FormDataValue> entity);
        Task<PaginatedResult<TransactionGridDto>> GetByFormPagedAsync(
            Guid formId,
            Guid? clientId,
            int pageNumber,
            int pageSize,
            bool ascending = true,
            CancellationToken cancellationToken = default);
    }

}
