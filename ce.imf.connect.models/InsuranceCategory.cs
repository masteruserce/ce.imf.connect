using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class InsuranceCategory
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? InsuranceType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatdDate { get; set; }
        public string CreatedBy { get; set; } = "System";
    }
}
