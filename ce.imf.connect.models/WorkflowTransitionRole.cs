using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class WorkflowTransitionRole
    {
        public Guid Id { get; set; }

        public Guid TransitionId { get; set; }
        public WorkflowTransition Transition { get; set; } = null!;
        public Guid RoleId { get; set; }
    }
}
