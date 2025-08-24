using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;

namespace ce.imf.connect.common.Mapper
{
    public static class FiftyBcDetailsMapper
    {
        public static FiftyBcDetailsDto ToDto(this FiftyBcDetails entity)
        {
            return new FiftyBcDetailsDto
            {
                Id = entity.Id,
                ApplicationNo = entity.ApplicationNo,
                SourcingId = entity.SourcingId,
                FiftyBcPcAmt = entity.FiftyBcPcAmt,
                TdsAmount = entity.TdsAmount,
                AmountClaimed = entity.AmountClaimed,
                AmountReceived = entity.AmountReceived,
                FiftyBcPcPending = entity.FiftyBcPcPending,
                CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy
            };
        }

        public static FiftyBcDetails ToEntity(this FiftyBcDetailsDto dto)
        {
            return new FiftyBcDetails
            {
                Id = dto.Id,
                ApplicationNo = dto.ApplicationNo,
                SourcingId = dto.SourcingId,
                FiftyBcPcAmt = dto.FiftyBcPcAmt,
                TdsAmount = dto.TdsAmount,
                AmountClaimed = dto.AmountClaimed,
                AmountReceived = dto.AmountReceived,
                FiftyBcPcPending = dto.FiftyBcPcPending,
                CreatedDate = dto.CreatedDate,
                CreatedBy = dto.CreatedBy,
                UpdatedDate = dto.UpdatedDate,
                UpdatedBy = dto.UpdatedBy
            };
        }

        public static void UpdateEntity(this FiftyBcDetails entity, FiftyBcDetailsDto dto)
        {
            entity.ApplicationNo = dto.ApplicationNo;
            entity.SourcingId = dto.SourcingId;
            entity.FiftyBcPcAmt = dto.FiftyBcPcAmt;
            entity.TdsAmount = dto.TdsAmount;
            entity.AmountClaimed = dto.AmountClaimed;
            entity.AmountReceived = dto.AmountReceived;
            entity.FiftyBcPcPending = dto.FiftyBcPcPending;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = dto.UpdatedBy;
        }
    }
}
