using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IInsuranceCategoryService
    {
        Task<ImfResponse<IEnumerable<InsuranceCategoryDto>>> GetByType(string insuranceType);
        Task<ImfResponse<IEnumerable<InsuranceCategoryDto>>> GetAllAsync();
        Task<ImfResponse<InsuranceCategoryDto>> GetByIdAsync(Guid id);
        Task<ImfResponse<InsuranceCategoryDto>> AddAsync(InsuranceCategoryDto dto);
        Task<ImfResponse<InsuranceCategoryDto>> UpdateAsync(InsuranceCategoryDto dto);
        Task<ImfResponse<bool>> DeleteAsync(Guid id);
    }
}
