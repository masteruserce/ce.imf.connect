using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class WorkflowTransition
    {
        public Guid Id { get; set; }

        public Guid TemplateId { get; set; }
        public WorkflowTemplate Template { get; set; } = null!;

        public Guid FromStateId { get; set; }
        public WorkflowState FromState { get; set; } = null!;

        public Guid ToStateId { get; set; }
        public WorkflowState ToState { get; set; } = null!;

        public string ActionName { get; set; } = null!;

        public bool RequiresApproval { get; set; }
        public bool AutoTransition { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<WorkflowTransitionRole> Roles { get; set; } = new List<WorkflowTransitionRole>();
    }
}
