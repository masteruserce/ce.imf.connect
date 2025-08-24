using ce.imf.connect.comon.DTOs;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IRevenueDetailsService
    {
        Task<ImfResponse<IEnumerable<RevenueDetailsDto>>> GetAllAsync();
        Task<ImfResponse<RevenueDetailsDto>> GetByIdAsync(Guid id);
        Task<ImfResponse<RevenueDetailsDto>> GetByApplicationNoAsync(string applicationNo);
        Task<ImfResponse<RevenueDetailsDto>> AddAsync(RevenueDetailsDto dto);
        Task<ImfResponse<RevenueDetailsDto>> UpdateAsync(RevenueDetailsDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}
