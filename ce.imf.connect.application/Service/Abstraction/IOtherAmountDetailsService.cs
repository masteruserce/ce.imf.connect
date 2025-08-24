using ce.imf.connect.comon.DTOs;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IOtherAmountDetailsService
    {
        Task<ImfResponse<IEnumerable<OtherAmountDetailsDto>>> GetAllAsync();
        Task<ImfResponse<OtherAmountDetailsDto>> GetByIdAsync(Guid id);
        Task<ImfResponse<OtherAmountDetailsDto>> GetByApplicationNoAsync(string applicationNo);
        Task<ImfResponse<OtherAmountDetailsDto>> AddAsync(OtherAmountDetailsDto dto);
        Task<ImfResponse<OtherAmountDetailsDto>> UpdateAsync(OtherAmountDetailsDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}