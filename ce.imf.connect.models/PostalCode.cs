using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class PostalCode
    {
       
        public long Id { get; set; }
        public string CircleName { get; set; } = string.Empty;
        public string RegionName { get; set; } = string.Empty;
        public string DivisionName { get; set; } = string.Empty;
        public string OfficeName { get; set; } = string.Empty;
        public int PinCode { get; set; }
        public string OfficeType { get; set; } = string.Empty;
        public string Delivery { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string StateName { get; set; } = string.Empty;
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
    }
}
