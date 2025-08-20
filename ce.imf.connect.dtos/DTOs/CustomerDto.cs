using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        // BaseModel fields
        public string CustomerNumber { get; set; } = string.Empty;
        public string? ItemType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsActive { get; set; }

        // Proposer Details
        public string Proposer { get; set; } = string.Empty;
        public DateTime ProposerDob { get; set; }
        public string ProposerPan { get; set; } = string.Empty;
        public string ProposerAadhar { get; set; } = string.Empty;
        public string ProposerGender { get; set; } = string.Empty;

        // Contact Details
        public string ProposerPhone { get; set; } = string.Empty;
        public string ProposerEmail { get; set; } = string.Empty;
        public string ProposerAddress { get; set; } = string.Empty;
        public string ProposerDistrict { get; set; } = string.Empty;
        public string ProposerPincode { get; set; } = string.Empty;
        public string ProposerState { get; set; } = string.Empty;

        // Life Assured Details
        public string LifeAssured { get; set; } = string.Empty;
        public DateTime LifeAssuredDob { get; set; }
        public string LifeAssuredPan { get; set; } = string.Empty;
        public string LifeAssuredAadhar { get; set; } = string.Empty;
        public string LifeAssuredGender { get; set; } = string.Empty;
        public string LifeAssuredPhone { get; set; } = string.Empty;
        public string LifeAssuredEmail { get; set; } = string.Empty;
        public string LifeAssuredAddress { get; set; } = string.Empty;
        public string LifeAssuredDistrict { get; set; } = string.Empty;
        public string LifeAssuredPincode { get; set; } = string.Empty;
        public string LifeAssuredState { get; set; } = string.Empty;

        // Nominee Details
        public string? Nominee { get; set; }
        public DateTime? NomineeDob { get; set; }
        public string? NomineePan { get; set; }
        public string? NomineeAadhar { get; set; }
        public string NomineeGender { get; set; } = string.Empty;
        public string? NomineePhone { get; set; }
        public string? NomineeEmail { get; set; }
        public string NomineeAddress { get; set; } = string.Empty;
        public string NomineeDistrict { get; set; } = string.Empty;
        public string NomineePincode { get; set; } = string.Empty;
        public string NomineeState { get; set; } = string.Empty;

        // Appointee Details
        public string? Appointee { get; set; }
        public DateTime? AppointeeDob { get; set; }
        public string? AppointeePan { get; set; }
        public string? AppointeeAadhar { get; set; }
        public string AppointeeGender { get; set; } = string.Empty;
        public string? AppointeePhone { get; set; }
        public string? AppointeeEmail { get; set; }
        public string? AppointeeAddress { get; set; }
        public string? AppointeeDistrict { get; set; }
        public string? AppointeePincode { get; set; }
        public string? AppointeeState { get; set; }

        public string? CustomerType { get; set; }
    }

}
