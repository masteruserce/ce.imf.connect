using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class WorkflowEventTrigger
    {
        public Guid Id { get; set; }

        public Guid SourceTemplateId { get; set; }
        public WorkflowTemplate SourceTemplate { get; set; } = null!;

        public Guid SourceStateId { get; set; }

        public Guid TargetFormId { get; set; }
        public Guid TargetTemplateId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
