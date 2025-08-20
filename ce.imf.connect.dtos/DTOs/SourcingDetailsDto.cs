using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class SourcingDetailsDto: BaseDto
    {
        public string Fy { get; set; }                 // e.g., "2024-25"
        public string SourceNumber { get; set; }
        public int Year { get; set; }                  // e.g., 2025
        public string LoginMonth { get; set; }         // e.g., "July"
        public string PremiumMonth { get; set; }       // e.g., "August"
        public string Location { get; set; }           // e.g., "Mumbai"
        public string Department { get; set; }         // e.g., "Sales"
        public string InsuranceHead { get; set; }      // Name of Insurance Head
        public string BusinessHead { get; set; }       // Name of Business Head
        public string Presentator { get; set; }        // Name of person presenting the case
        public string BusinessPartner { get; set; }    // Partner company/person
        public string InsuranceCategory { get; set; }  // Life | Health | General
        public string FreshRenewal { get; set; }       // Fresh | Renewal
        public string PrincipalCo { get; set; }        // Name of principal company
        public string PlanType { get; set; }           // ULIP | Non-ULIP | Term
        public string EmpCode { get; set; }            // Employee code
        public string ApplicationNo { get; set; }      // Application reference number
    }

}
