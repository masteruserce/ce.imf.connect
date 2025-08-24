using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    using System;

    namespace InsuranceApp.Models
    {
        public class PayoutDetails
        {
            public Guid Id { get; set; }
            public string ApplicationNo { get; set; } = string.Empty;
            public Guid SourcingId { get; set; }

            public decimal? PayoutPercentage { get; set; }
            public string? PayoutMonth { get; set; }
            public decimal? PayoutAmount { get; set; }
            public decimal? TdsDeducted { get; set; }
            public decimal? NetPayoutAmount { get; set; }
            public decimal? AmountPaid { get; set; }
            public decimal? BalancePayable { get; set; }
            public string? PayoutStatus { get; set; }
            public DateTime? PaidDate { get; set; }
            public string? PayeeName { get; set; }
            public string? PaymentMode { get; set; }
            public string? BankAccountNo { get; set; }
            public string? BankHolderName { get; set; }
            public string? BankName { get; set; }
            public string? IfscCode { get; set; }

            public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
            public Guid? CreatedBy { get; set; }
            public DateTime? UpdatedDate { get; set; }
            public Guid? UpdatedBy { get; set; }
            public bool IsActive { get; set; } = true;
        }
    }

}
