using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class FieldConfig
    {
        public Guid Id { get; set; }
        public Guid? ClientId { get; set; }
        public Guid SectionId { get; set; }
        public string FieldName { get; set; } = string.Empty;  // name -> underscored
        public int FieldOrder { get; set; } = 0;
        public string Type { get; set; } = "text"; // default
        public string? Label { get; set; }
        public string? Placeholder { get; set; }
        public string? Options { get; set; } // CSV or JSON string
        public bool Required { get; set; } = false;
        public string? ValidationMessage { get; set; }
        public string? DefaultValue { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Section? Section { get; set; }
        public Clients? Client { get; set; }
    }
}
