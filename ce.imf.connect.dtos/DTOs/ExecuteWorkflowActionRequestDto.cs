using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class ExecuteWorkflowActionRequestDto
    {
        public string TransactionId { get; set; } = null!;
        public string ActionName { get; set; } = null!;
        public Guid UserRoleId { get; set; }
        public string PerformedBy { get; set; } = null!;
        public string? Comments { get; set; }
    }
}
