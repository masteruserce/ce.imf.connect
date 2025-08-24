using ce.imf.connect.comon.DTOs;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IFinalDetailsService
    {
        Task<ImfResponse<IEnumerable<FinalDetailsDto>>> GetAllAsync();
        Task<ImfResponse<FinalDetailsDto>> GetByIdAsync(Guid id);
        Task<ImfResponse<FinalDetailsDto>> GetByApplicationNoAsync(string applicationNo);
        Task<ImfResponse<FinalDetailsDto>> AddAsync(FinalDetailsDto dto);
        Task<ImfResponse<FinalDetailsDto>> UpdateAsync(FinalDetailsDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}
