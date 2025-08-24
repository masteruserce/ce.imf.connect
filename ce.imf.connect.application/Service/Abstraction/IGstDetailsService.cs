using ce.imf.connect.comon.DTOs;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IGstDetailsService
    {
        Task<ImfResponse<IEnumerable<GstDetailsDto>>> GetAllAsync();
        Task<ImfResponse<GstDetailsDto>> GetByIdAsync(Guid id);
        Task<ImfResponse<GstDetailsDto>> GetByApplicationNoAsync(string applicationNo);
        Task<ImfResponse<GstDetailsDto>> AddAsync(GstDetailsDto dto);
        Task<ImfResponse<GstDetailsDto>> UpdateAsync(GstDetailsDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}
