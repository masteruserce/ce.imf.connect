using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class WorkflowTemplate
    {
        public Guid Id { get; set; }
        public Guid? ClientId { get; set; }
        public Guid FormId { get; set; }

        public string Name { get; set; } = null!;
        public int Version { get; set; } = 1;

        public bool IsActive { get; set; } = true;
        public bool IsSystemTemplate { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public ICollection<WorkflowState> States { get; set; } = new List<WorkflowState>();
        public ICollection<WorkflowTransition> Transitions { get; set; } = new List<WorkflowTransition>();
    }
}
