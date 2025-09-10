using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.Mapper
{
    public static class InsuranceCategoryMapper
    {
        public static InsuranceCategoryDto ToDto(this InsuranceCategory entity)
        {
            return new InsuranceCategoryDto
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Description = entity.Description,
                InsuranceType = entity.InsuranceType,
                IsActive = entity.IsActive
            };
        }

        public static InsuranceCategory ToEntity(this InsuranceCategoryDto dto)
        {
            return new InsuranceCategory
            {
                CategoryId = dto.CategoryId == Guid.Empty ? Guid.NewGuid() : dto.CategoryId,
                CategoryName = dto.CategoryName,
                Description = dto.Description,
                InsuranceType = dto.InsuranceType,
                IsActive = dto.IsActive,
                CreatdDate = DateTime.UtcNow,
                CreatedBy = "System"
            };
        }
    }
}
