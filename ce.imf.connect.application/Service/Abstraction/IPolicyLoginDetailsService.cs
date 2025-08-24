using ce.imf.connect.comon.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IPolicyLoginDetailsService
    {
        Task<ImfResponse<IEnumerable<PolicyLoginDetailsDto>>> GetAllAsync();
        Task<ImfResponse<PolicyLoginDetailsDto?>> GetByIdAsync(Guid id);
        Task<ImfResponse<PolicyLoginDetailsDto>> AddAsync(PolicyLoginDetailsDto dto);
        Task<ImfResponse<PolicyLoginDetailsDto?>> UpdateAsync(PolicyLoginDetailsDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}
