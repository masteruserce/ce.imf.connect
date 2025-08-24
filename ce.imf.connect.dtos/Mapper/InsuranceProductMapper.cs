using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models; // Assuming your EF Models namespace

namespace ce.imf.connect.comon.Mapper
{
    public static class InsuranceProductMapper
    {
        public static InsuranceProductDto ToDto(this InsuranceProduct entity)
        {
            if (entity == null) return null!;
            return new InsuranceProductDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Manufacturer = entity.Manufacturer,
                Term = entity.Term,
                PaymentTerm = entity.PaymentTerm,
                PaymentMode = entity.PaymentMode,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate,
                CreatedBy = entity.CreatedBy,
                UpdatedBy = entity.UpdatedBy,
                IsActive = entity.IsActive
            };
        }

        public static InsuranceProduct ToEntity(this InsuranceProductDto dto)
        {
            if (dto == null) return null!;
            return new InsuranceProduct
            {
                Id = dto.Id,
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Term = dto.Term,
                PaymentTerm = dto.PaymentTerm,
                PaymentMode = dto.PaymentMode,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                IsActive = dto.IsActive
            };
        }
    }
}
