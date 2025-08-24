using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;

namespace ce.imf.connect.common.Mapper
{
    public static class PcDetailsMapper
    {
        public static PcDetailsDto ToDto(this PcDetails entity)
        {
            return new PcDetailsDto
            {
                Id = entity.Id,
                ApplicationNo = entity.ApplicationNo,
                SourcingId = entity.SourcingId,
                PcCommAmt = entity.PcCommAmt,
                TdsAmount = entity.TdsAmount,
                AmtClaimed = entity.AmtClaimed,
                AmtReceived = entity.AmtReceived,
                PcPending = entity.PcPending,
                CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy
            };
        }

        public static PcDetails ToEntity(this PcDetailsDto dto)
        {
            return new PcDetails
            {
                Id = dto.Id,
                ApplicationNo = dto.ApplicationNo,
                SourcingId = dto.SourcingId,
                PcCommAmt = dto.PcCommAmt,
                TdsAmount = dto.TdsAmount,
                AmtClaimed = dto.AmtClaimed,
                AmtReceived = dto.AmtReceived,
                PcPending = dto.PcPending,
                CreatedDate = dto.CreatedDate,
                CreatedBy = dto.CreatedBy,
                UpdatedDate = dto.UpdatedDate,
                UpdatedBy = dto.UpdatedBy
            };
        }

        public static void UpdateEntity(this PcDetails entity, PcDetailsDto dto)
        {
            entity.ApplicationNo = dto.ApplicationNo;
            entity.SourcingId = dto.SourcingId;
            entity.PcCommAmt = dto.PcCommAmt;
            entity.TdsAmount = dto.TdsAmount;
            entity.AmtClaimed = dto.AmtClaimed;
            entity.AmtReceived = dto.AmtReceived;
            entity.PcPending = dto.PcPending;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = dto.UpdatedBy;
        }
    }
}
