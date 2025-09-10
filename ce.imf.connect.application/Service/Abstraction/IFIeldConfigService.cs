namespace ce.imf.connect.application.Service.Abstraction
{
    using ce.imf.connect.comon.DTOs;
    using ce.imf.connect.models;
    using System.Threading.Tasks;

    public interface IFieldConfigService
    {
        Task<ImfResponse<IEnumerable<FieldConfigDto>>> GetAllAsync();
        Task<ImfResponse<FieldConfigDto>> GetByIdAsync(Guid id);
        Task<ImfResponse<IEnumerable<FieldConfigDto>>> AddRangeAsync(ImportFieldsRequest dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
        Task<ImfResponse<FieldConfigDto>> UpdateAsync(FieldConfigDto entity);
        Task<ImfResponse<IEnumerable<FieldConfigDto>>> GetByIdAsyncbyClientIdAndFormName(Guid clientId, string formName);
    }
}