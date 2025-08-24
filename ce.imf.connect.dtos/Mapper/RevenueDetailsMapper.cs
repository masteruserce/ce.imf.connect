using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;

namespace ce.imf.connect.common.Mapper
{
    public static class RevenueDetailsMapper
    {
        public static RevenueDetailsDto ToDto(this RevenueDetails entity)
        {
            return new RevenueDetailsDto
            {
                Id = entity.Id,
                ApplicationNo = entity.ApplicationNo,
                SourcingId = entity.SourcingId,
                TotalRevenuePercent = entity.TotalRevenuePercent,
                BasePercent = entity.BasePercent,
                PcPercent = entity.PcPercent,
                Bc50Percent = entity.Bc50Percent,
                OrcPercent = entity.OrcPercent,
                ContestPercent = entity.ContestPercent,
                PliPercent = entity.PliPercent,
                CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy
            };
        }

        public static RevenueDetails ToEntity(this RevenueDetailsDto dto)
        {
            return new RevenueDetails
            {
                Id = dto.Id,
                ApplicationNo = dto.ApplicationNo,
                SourcingId = dto.SourcingId,
                TotalRevenuePercent = dto.TotalRevenuePercent,
                BasePercent = dto.BasePercent,
                PcPercent = dto.PcPercent,
                Bc50Percent = dto.Bc50Percent,
                OrcPercent = dto.OrcPercent,
                ContestPercent = dto.ContestPercent,
                PliPercent = dto.PliPercent,
                CreatedDate = dto.CreatedDate,
                CreatedBy = dto.CreatedBy,
                UpdatedDate = dto.UpdatedDate,
                UpdatedBy = dto.UpdatedBy
            };
        }

        public static void UpdateEntity(this RevenueDetails entity, RevenueDetailsDto dto)
        {
            entity.ApplicationNo = dto.ApplicationNo;
            entity.SourcingId = dto.SourcingId;
            entity.TotalRevenuePercent = dto.TotalRevenuePercent;
            entity.BasePercent = dto.BasePercent;
            entity.PcPercent = dto.PcPercent;
            entity.Bc50Percent = dto.Bc50Percent;
            entity.OrcPercent = dto.OrcPercent;
            entity.ContestPercent = dto.ContestPercent;
            entity.PliPercent = dto.PliPercent;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = dto.UpdatedBy;
        }
    }
}
