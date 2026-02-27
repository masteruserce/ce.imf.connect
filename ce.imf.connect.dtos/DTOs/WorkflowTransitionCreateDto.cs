using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class WorkflowTransitionCreateDto
    {
        public Guid Id { get; set; }
        public Guid FromStateId { get; set; }
        public Guid ToStateId { get; set; }
        public string ActionName { get; set; } = null!;
        public bool RequiresApproval { get; set; }
        public bool AutoTransition { get; set; }
        public List<Guid> RoleIds { get; set; } = new();
    }
}
