using ce.imf.connect.comon.DTOs;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IInsuranceProductService
    {
        Task<ImfResponse<InsuranceProductDto?>> GetByIdAsync(Guid id);
        Task<ImfResponse<IEnumerable<InsuranceProductDto>>> GetAllAsync();
        Task<ImfResponse<InsuranceProductDto>> AddAsync(InsuranceProductDto dto);
        Task<ImfResponse<InsuranceProductDto?>> UpdateAsync(InsuranceProductDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}
