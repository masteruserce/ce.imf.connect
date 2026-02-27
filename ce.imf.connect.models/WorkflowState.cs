using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class WorkflowState
    {
        public Guid Id { get; set; }

        public Guid TemplateId { get; set; }
        public WorkflowTemplate Template { get; set; } = null!;

        public string Name { get; set; } = null!;
        public int Sequence { get; set; }

        public bool IsStart { get; set; }
        public bool IsEnd { get; set; }

        public bool AllowEdit { get; set; }

        public int? SLAHours { get; set; }
        public Guid? EscalationRoleId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<WorkflowTransition> FromTransitions { get; set; } = new List<WorkflowTransition>();
        public ICollection<WorkflowTransition> ToTransitions { get; set; } = new List<WorkflowTransition>();
    }
}
