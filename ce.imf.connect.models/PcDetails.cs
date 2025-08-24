using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class PcDetails
    {
        public Guid Id { get; set; }
        public string ApplicationNo { get; set; } = string.Empty;
        public Guid SourcingId { get; set; }

        public decimal? PcCommAmt { get; set; }
        public decimal? TdsAmount { get; set; }
        public decimal? AmtClaimed { get; set; }
        public decimal? AmtReceived { get; set; }
        public decimal? PcPending { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
