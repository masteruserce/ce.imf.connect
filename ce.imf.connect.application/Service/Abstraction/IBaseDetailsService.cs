using ce.imf.connect.comon.DTOs;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IBaseDetailsService
    {
        Task<ImfResponse<IEnumerable<BaseDetailsDto>>> GetAllAsync();
        Task<ImfResponse<BaseDetailsDto>> GetByIdAsync(Guid id);
        Task<ImfResponse<BaseDetailsDto>> GetByApplicationNoAsync(string applicationNo);
        Task<ImfResponse<BaseDetailsDto>> AddAsync(BaseDetailsDto dto);
        Task<ImfResponse<BaseDetailsDto>> UpdateAsync(BaseDetailsDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}
