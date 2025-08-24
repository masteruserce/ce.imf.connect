using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class OtherAmountDetails
    {
        public Guid Id { get; set; }
        public string ApplicationNo { get; set; } = string.Empty;
        public Guid SourcingId { get; set; }

        public decimal? OrcCommAmt { get; set; }
        public decimal? TdsAmt { get; set; }
        public decimal? AmountClaimed { get; set; }
        public decimal? AmountReceived { get; set; }
        public decimal? OrcPending { get; set; }
        public decimal? ApartBcOrcComm { get; set; }
        public decimal? TotalPending { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsActive { get; set; } = true;
    }

}
