using ce.imf.connect.comon.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface ISourcingDetailsService
    {
        Task<ImfResponse<SourcingDetailsDto>> GetByIdAsync(Guid id);
        Task<ImfResponse<IEnumerable<SourcingDetailsDto>>> GetAllAsync();
        Task<ImfResponse<SourcingDetailsDto>> CreateAsync(SourcingDetailsDto dto);
        Task<ImfResponse<SourcingDetailsDto>> UpdateAsync(SourcingDetailsDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}
