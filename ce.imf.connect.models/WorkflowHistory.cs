using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class WorkflowHistory
    {
        public Guid Id { get; set; }

        public Guid InstanceId { get; set; }
        public WorkflowInstance Instance { get; set; } = null!;

        public Guid FromStateId { get; set; }
        public Guid ToStateId { get; set; }

        public string ActionName { get; set; } = null!;
        public string PerformedBy { get; set; } = null!;

        public string? Comments { get; set; }

        public DateTime PerformedAt { get; set; } = DateTime.UtcNow;

        public string? IPAddress { get; set; }
        public string? DeviceInfo { get; set; }
    }
}
