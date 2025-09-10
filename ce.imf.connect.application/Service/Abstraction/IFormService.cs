using ce.imf.connect.comon.DTOs;
namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IFormService
    {
        Task<ImfResponse<FormDto>> GetFormAsync(Guid? clientId, string formName);
        Task<ImfResponse<FormDto>> ImportFormAsync(ImportFieldsRequest request);
    }
}
