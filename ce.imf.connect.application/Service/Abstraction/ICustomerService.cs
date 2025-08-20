using ce.imf.connect.comon.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface ICustomerService
    {
        Task<ImfResponse<CustomerDto>> GetByIdAsync(Guid id);
        Task<ImfResponse<IEnumerable<CustomerDto>>> GetAllAsync();
        Task<ImfResponse<CustomerDto>> CreateAsync(CustomerDto dto);
        Task<ImfResponse<CustomerDto>> UpdateAsync(CustomerDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}
