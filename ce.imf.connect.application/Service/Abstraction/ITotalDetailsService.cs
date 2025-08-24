using ce.imf.connect.comon.DTOs;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface ITotalDetailsService
    {
        Task<ImfResponse<IEnumerable<TotalDetailsDto>>> GetAllAsync();
        Task<ImfResponse<TotalDetailsDto>> GetByIdAsync(Guid id);
        Task<ImfResponse<TotalDetailsDto>> GetByApplicationNoAsync(string applicationNo);
        Task<ImfResponse<TotalDetailsDto>> AddAsync(TotalDetailsDto dto);
        Task<ImfResponse<TotalDetailsDto>> UpdateAsync(TotalDetailsDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}