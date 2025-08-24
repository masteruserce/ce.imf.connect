using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class RevenueDetailsDto
    {
        public Guid Id { get; set; }
        public string ApplicationNo { get; set; } = string.Empty;
        public Guid SourcingId { get; set; }
        public decimal? TotalRevenuePercent { get; set; }
        public decimal? BasePercent { get; set; }
        public decimal? PcPercent { get; set; }
        public decimal? Bc50Percent { get; set; }
        public decimal? OrcPercent { get; set; }
        public decimal? ContestPercent { get; set; }
        public decimal? PliPercent { get; set; }

        // audit
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
