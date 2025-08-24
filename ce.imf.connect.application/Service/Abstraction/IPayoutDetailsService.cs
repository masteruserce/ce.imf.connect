using ce.imf.connect.comon.DTOs;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IPayoutDetailsService
    {
        Task<ImfResponse<IEnumerable<PayoutDetailsDto>>> GetAllAsync();
        Task<ImfResponse<PayoutDetailsDto>> GetByIdAsync(Guid id);
        Task<ImfResponse<PayoutDetailsDto>> GetByApplicationNoAsync(string applicationNo);
        Task<ImfResponse<PayoutDetailsDto>> AddAsync(PayoutDetailsDto dto);
        Task<ImfResponse<PayoutDetailsDto>> UpdateAsync(PayoutDetailsDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}
