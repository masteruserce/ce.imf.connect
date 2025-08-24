using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;

namespace ce.imf.connect.common.Mapper
{
    public static class FinalDetailsMapper
    {
        public static FinalDetailsDto ToDto(this FinalDetails entity)
        {
            return new FinalDetailsDto
            {
                Id = entity.Id,
                ApplicationNo = entity.ApplicationNo,
                SourcingId = entity.SourcingId,
                TotalCommAmt = entity.TotalCommAmt,
                TotalCommissionReceived = entity.TotalCommissionReceived,
                BaseCommAmt = entity.BaseCommAmt,
                TdsAmount = entity.TdsAmount,
                AmtClaimed = entity.AmtClaimed,
                AmtReceived = entity.AmtReceived,
                BasePending = entity.BasePending,
                CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy
            };
        }

        public static FinalDetails ToEntity(this FinalDetailsDto dto)
        {
            return new FinalDetails
            {
                Id = dto.Id,
                ApplicationNo = dto.ApplicationNo,
                SourcingId = dto.SourcingId,
                TotalCommAmt = dto.TotalCommAmt,
                TotalCommissionReceived = dto.TotalCommissionReceived,
                BaseCommAmt = dto.BaseCommAmt,
                TdsAmount = dto.TdsAmount,
                AmtClaimed = dto.AmtClaimed,
                AmtReceived = dto.AmtReceived,
                BasePending = dto.BasePending,
                CreatedDate = dto.CreatedDate,
                CreatedBy = dto.CreatedBy,
                UpdatedDate = dto.UpdatedDate,
                UpdatedBy = dto.UpdatedBy
            };
        }

        public static void UpdateEntity(this FinalDetails entity, FinalDetailsDto dto)
        {
            entity.ApplicationNo = dto.ApplicationNo;
            entity.SourcingId = dto.SourcingId;
            entity.TotalCommAmt = dto.TotalCommAmt;
            entity.TotalCommissionReceived = dto.TotalCommissionReceived;
            entity.BaseCommAmt = dto.BaseCommAmt;
            entity.TdsAmount = dto.TdsAmount;
            entity.AmtClaimed = dto.AmtClaimed;
            entity.AmtReceived = dto.AmtReceived;
            entity.BasePending = dto.BasePending;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = dto.UpdatedBy;
        }
    }
}
