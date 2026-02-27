using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class WorkflowTemplateCreateDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid FormId { get; set; }
        public Guid? ClientId { get; set; }

        public List<WorkflowStateCreateDto> States { get; set; } = new();
        public List<WorkflowTransitionCreateDto> Transitions { get; set; } = new();
    }
}
