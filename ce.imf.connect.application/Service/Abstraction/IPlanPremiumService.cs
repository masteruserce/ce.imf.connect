using ce.imf.connect.comon.DTOs;
namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IPlanPremiumService
    {
        Task<ImfResponse<IEnumerable<PlanPremiumDetailsDto>>> GetAllAsync();
        Task<ImfResponse<PlanPremiumDetailsDto?>> GetByIdAsync(Guid id);
        Task<ImfResponse<PlanPremiumDetailsDto>> AddAsync(PlanPremiumDetailsDto dto);
        Task<ImfResponse<PlanPremiumDetailsDto?>> UpdateAsync(PlanPremiumDetailsDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}
