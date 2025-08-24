using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;

namespace ce.imf.connect.common.Mapper
{
    public static class GstDetailsMapper
    {
        public static GstDetailsDto ToDto(this GstDetails entity)
        {
            return new GstDetailsDto
            {
                Id = entity.Id,
                ApplicationNo = entity.ApplicationNo,
                SourcingId = entity.SourcingId,
                Gst18 = entity.Gst18,
                GstReceived = entity.GstReceived,
                PendingGst = entity.PendingGst,
                CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy
            };
        }

        public static GstDetails ToEntity(this GstDetailsDto dto)
        {
            return new GstDetails
            {
                Id = dto.Id,
                ApplicationNo = dto.ApplicationNo,
                SourcingId = dto.SourcingId,
                Gst18 = dto.Gst18,
                GstReceived = dto.GstReceived,
                PendingGst = dto.PendingGst,
                CreatedDate = dto.CreatedDate,
                CreatedBy = dto.CreatedBy,
                UpdatedDate = dto.UpdatedDate,
                UpdatedBy = dto.UpdatedBy
            };
        }

        public static void UpdateEntity(this GstDetails entity, GstDetailsDto dto)
        {
            entity.ApplicationNo = dto.ApplicationNo;
            entity.SourcingId = dto.SourcingId;
            entity.Gst18 = dto.Gst18;
            entity.GstReceived = dto.GstReceived;
            entity.PendingGst = dto.PendingGst;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = dto.UpdatedBy;
        }
    }
}
