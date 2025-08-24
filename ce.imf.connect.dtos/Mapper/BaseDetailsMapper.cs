using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;

namespace ce.imf.connect.common.Mapper
{
    public static class BaseDetailsMapper
    {
        public static BaseDetailsDto ToDto(this BaseDetails entity)
        {
            return new BaseDetailsDto
            {
                Id = entity.Id,
                ApplicationNo = entity.ApplicationNo,
                SourcingId = entity.SourcingId,
                TotalCommAmt = entity.TotalCommAmt,
                TotalCommReceived = entity.TotalCommReceived,
                BaseCommAmt = entity.BaseCommAmt,
                TdsAmount = entity.TdsAmount,
                AmountClaimed = entity.AmountClaimed,
                AmountReceived = entity.AmountReceived,
                BasePending = entity.BasePending,
                CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy
            };
        }

        public static BaseDetails ToEntity(this BaseDetailsDto dto)
        {
            return new BaseDetails
            {
                Id = dto.Id,
                ApplicationNo = dto.ApplicationNo,
                SourcingId = dto.SourcingId,
                TotalCommAmt = dto.TotalCommAmt,
                TotalCommReceived = dto.TotalCommReceived,
                BaseCommAmt = dto.BaseCommAmt,
                TdsAmount = dto.TdsAmount,
                AmountClaimed = dto.AmountClaimed,
                AmountReceived = dto.AmountReceived,
                BasePending = dto.BasePending,
                CreatedDate = dto.CreatedDate,
                CreatedBy = dto.CreatedBy,
                UpdatedDate = dto.UpdatedDate,
                UpdatedBy = dto.UpdatedBy
            };
        }

        public static void UpdateEntity(this BaseDetails entity, BaseDetailsDto dto)
        {
            entity.ApplicationNo = dto.ApplicationNo;
            entity.SourcingId = dto.SourcingId;
            entity.TotalCommAmt = dto.TotalCommAmt;
            entity.TotalCommReceived = dto.TotalCommReceived;
            entity.BaseCommAmt = dto.BaseCommAmt;
            entity.TdsAmount = dto.TdsAmount;
            entity.AmountClaimed = dto.AmountClaimed;
            entity.AmountReceived = dto.AmountReceived;
            entity.BasePending = dto.BasePending;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = dto.UpdatedBy;
        }
    }
}
