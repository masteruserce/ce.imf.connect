using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class WorkflowStateCreateDto
    {
        public Guid Id { get; set; }  // client temp id or existing
        public string Name { get; set; } = null!;
        public int Sequence { get; set; }
        public bool IsStart { get; set; }
        public bool IsEnd { get; set; }
        public bool AllowEdit { get; set; }
    }
}
