using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class InsuranceProduct: BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string Term { get; set; } = string.Empty;
        public string PaymentTerm { get; set; } = string.Empty;
        public string PaymentMode { get; set; } = string.Empty;
    }
}
