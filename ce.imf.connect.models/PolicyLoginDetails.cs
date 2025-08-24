using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class PolicyLoginDetails
    {
        public Guid Id { get; set; }
        public string ApplicationNo { get; set; } = string.Empty;
        public Guid SourcingId { get; set; }
        public DateTime? PrincipalCoLoginDate { get; set; }
        public string? PolicyNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? PolicyStatus { get; set; }
        public string? WorkFlowStatus { get; set; }
        public string? PlvcStatus { get; set; }
        public DateTime? PaidToDate { get; set; }
        public string? PlvcDescription { get; set; }
        public string? PolicyType { get; set; }
    }

}
