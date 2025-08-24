using ce.imf.connect.comon.DTOs;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IPcDetailsService
    {
        Task<ImfResponse<IEnumerable<PcDetailsDto>>> GetAllAsync();
        Task<ImfResponse<PcDetailsDto>> GetByIdAsync(Guid id);
        Task<ImfResponse<PcDetailsDto>> GetByApplicationNoAsync(string applicationNo);
        Task<ImfResponse<PcDetailsDto>> AddAsync(PcDetailsDto dto);
        Task<ImfResponse<PcDetailsDto>> UpdateAsync(PcDetailsDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}
