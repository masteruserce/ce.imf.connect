using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class WorkflowAvailableActionsDto
    {
        public string TransactionId { get; set; } = null!;
        public string CurrentState { get; set; } = null!;
        public List<string> AvailableActions { get; set; } = new();
    }
}
