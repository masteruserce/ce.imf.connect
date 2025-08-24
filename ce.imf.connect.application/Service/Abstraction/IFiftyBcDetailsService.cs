using ce.imf.connect.comon.DTOs;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IFiftyBcDetailsService
    {
        Task<ImfResponse<IEnumerable<FiftyBcDetailsDto>>> GetAllAsync();
        Task<ImfResponse<FiftyBcDetailsDto>> GetByIdAsync(Guid id);
        Task<ImfResponse<FiftyBcDetailsDto>> GetByApplicationNoAsync(string applicationNo);
        Task<ImfResponse<FiftyBcDetailsDto>> AddAsync(FiftyBcDetailsDto dto);
        Task<ImfResponse<FiftyBcDetailsDto>> UpdateAsync(FiftyBcDetailsDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}
