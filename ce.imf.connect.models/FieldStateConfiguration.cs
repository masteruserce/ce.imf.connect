using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class FieldStateConfiguration
    {
        public Guid Id { get; set; }

        public Guid FieldId { get; set; }

        public Guid StateId { get; set; }
        public WorkflowState State { get; set; } = null!;

        public bool IsVisible { get; set; } = true;
        public bool IsEditable { get; set; } = true;
        public bool IsMandatory { get; set; }
    }
}
