using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class WorkflowInstance
    {
        public Guid Id { get; set; }

        public string TransactionId { get; set; } = null!;
        public Guid TemplateId { get; set; }
        public WorkflowTemplate Template { get; set; } = null!;

        public Guid CurrentStateId { get; set; }
        public WorkflowState CurrentState { get; set; } = null!;

        public Guid? ClientId { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }

        public bool IsCompleted { get; set; }

        public ICollection<WorkflowHistory> History { get; set; } = new List<WorkflowHistory>();
    }
}
