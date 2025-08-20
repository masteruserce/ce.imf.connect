using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class BasicDetailsDto:BaseDto
    {
        public string CustomerNumber { get; set; }  // e.g., "CUST12345"
        public string? Name { get; set; }
        public required DateTime Dob { get; set; }  // ISO string like "2025-06-15"
        public string? Pan { get; set; }
        public required string Gender { get; set; }
        public string? Aadhar { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? District { get; set; }
        public string? Pincode { get; set; }
        public string? State { get; set; }
        public bool CanCopyDetails { get; set; }
        public bool CanCopyAddress { get; set; }
    }
}
