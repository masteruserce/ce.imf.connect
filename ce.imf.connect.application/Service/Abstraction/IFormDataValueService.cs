using ce.imf.connect.common.DTOs;
using ce.imf.connect.comon.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IFormDataValueService
    {
        Task<ImfResponse<FormDataValueDto>> SaveAsync(FormDataValueDto dto);
        Task<ImfResponse<FormDataValueDto>> UpdateAsync(FormDataValueDto dto);
        Task<ImfResponse<bool>> ActivateAsync(Guid id);
        Task<ImfResponse<bool>> DeactivateAsync(Guid id);
        Task<ImfResponse<IEnumerable<FormDataValueDto>>> GetByFormAsync(Guid formId, Guid? clientId);
    }

}
