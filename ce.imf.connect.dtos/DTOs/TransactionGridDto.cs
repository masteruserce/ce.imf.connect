using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class TransactionGridDto
    {
        public string TransactionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy  { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public Dictionary<string, string?> Fields { get; set; }
    }
}
