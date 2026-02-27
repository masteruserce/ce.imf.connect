using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class InitializeWorkflowRequestDto
    {
        public string TransactionId { get; set; } = null!;
        public Guid FormId { get; set; }
        public Guid? ClientId { get; set; }
        public string InitiatedBy { get; set; } = null!;
    }
}
