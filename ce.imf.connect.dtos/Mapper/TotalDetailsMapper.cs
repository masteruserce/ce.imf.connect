using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;

namespace ce.imf.connect.common.Mapper
{
    public static class TotalDetailsMapper
    {
        public static TotalDetailsDto ToDto(this TotalDetails entity)
        {
            return new TotalDetailsDto
            {
                Id = entity.Id,
                ApplicationNo = entity.ApplicationNo,
                SourcingId = entity.SourcingId,
                TotalReceivable = entity.TotalReceivable,
                TotalReceived = entity.TotalReceived,
                PendingTotal = entity.PendingTotal,
                CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy
            };
        }

        public static TotalDetails ToEntity(this TotalDetailsDto dto)
        {
            return new TotalDetails
            {
                Id = dto.Id,
                ApplicationNo = dto.ApplicationNo,
                SourcingId = dto.SourcingId,
                TotalReceivable = dto.TotalReceivable,
                TotalReceived = dto.TotalReceived,
                PendingTotal = dto.PendingTotal,
                CreatedDate = dto.CreatedDate,
                CreatedBy = dto.CreatedBy,
                UpdatedDate = dto.UpdatedDate,
                UpdatedBy = dto.UpdatedBy
            };
        }

        public static void UpdateEntity(this TotalDetails entity, TotalDetailsDto dto)
        {
            entity.ApplicationNo = dto.ApplicationNo;
            entity.SourcingId = dto.SourcingId;
            entity.TotalReceivable = dto.TotalReceivable;
            entity.TotalReceived = dto.TotalReceived;
            entity.PendingTotal = dto.PendingTotal;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = dto.UpdatedBy;
        }
    }
}
