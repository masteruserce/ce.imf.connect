using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;

namespace ce.imf.connect.common.Mapper
{
    public static class OtherAmountDetailsMapper
    {
        public static OtherAmountDetailsDto ToDto(this OtherAmountDetails entity)
        {
            return new OtherAmountDetailsDto
            {
                Id = entity.Id,
                ApplicationNo = entity.ApplicationNo,
                SourcingId = entity.SourcingId,
                OrcCommAmt = entity.OrcCommAmt,
                TdsAmt = entity.TdsAmt,
                AmountClaimed = entity.AmountClaimed,
                AmountReceived = entity.AmountReceived,
                OrcPending = entity.OrcPending,
                ApartBcOrcComm = entity.ApartBcOrcComm,
                TotalPending = entity.TotalPending,
                CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy
            };
        }

        public static OtherAmountDetails ToEntity(this OtherAmountDetailsDto dto)
        {
            return new OtherAmountDetails
            {
                Id = dto.Id,
                ApplicationNo = dto.ApplicationNo,
                SourcingId = dto.SourcingId,
                OrcCommAmt = dto.OrcCommAmt,
                TdsAmt = dto.TdsAmt,
                AmountClaimed = dto.AmountClaimed,
                AmountReceived = dto.AmountReceived,
                OrcPending = dto.OrcPending,
                ApartBcOrcComm = dto.ApartBcOrcComm,
                TotalPending = dto.TotalPending,
                CreatedDate = dto.CreatedDate,
                CreatedBy = dto.CreatedBy,
                UpdatedDate = dto.UpdatedDate,
                UpdatedBy = dto.UpdatedBy
            };
        }

        public static void UpdateEntity(this OtherAmountDetails entity, OtherAmountDetailsDto dto)
        {
            entity.ApplicationNo = dto.ApplicationNo;
            entity.SourcingId = dto.SourcingId;
            entity.OrcCommAmt = dto.OrcCommAmt;
            entity.TdsAmt = dto.TdsAmt;
            entity.AmountClaimed = dto.AmountClaimed;
            entity.AmountReceived = dto.AmountReceived;
            entity.OrcPending = dto.OrcPending;
            entity.ApartBcOrcComm = dto.ApartBcOrcComm;
            entity.TotalPending = dto.TotalPending;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = dto.UpdatedBy;
        }
    }
}
