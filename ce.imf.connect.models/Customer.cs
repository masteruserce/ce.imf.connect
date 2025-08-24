namespace ce.imf.connect.models
{
    public class Customer : BaseModel
    {
        // Proposer Details
        public required string CustomerNumber { get; set; }
        public required string SourcingId { get; set; }
        public required string ApplicationNo { get; set; }
        public required string Proposer { get; set; }
        public required DateTime ProposerDob { get; set; }
        public required string ProposerPan { get; set; }
        public required string ProposerAadhar { get; set; }
        public required string ProposerGender { get; set; }

        // Contact Details
        public required string ProposerPhone { get; set; }
        public required string ProposerEmail { get; set; }
        public required string ProposerAddress { get; set; }
        public required string ProposerDistrict { get; set; }
        public required string ProposerPincode { get; set; }
        public required string ProposerState { get; set; }

        // Life Assured Details
        public required string LifeAssured { get; set; }
        public DateTime LifeAssuredDob { get; set; }
        public required string LifeAssuredPan { get; set; }
        public required string LifeAssuredAadhar { get; set; }
        public required string LifeAssuredGender { get; set; }

        public required string LifeAssuredPhone { get; set; }
        public required string LifeAssuredEmail { get; set; }
        public required string LifeAssuredAddress { get; set; }
        public required string LifeAssuredDistrict { get; set; }
        public required string LifeAssuredPincode { get; set; }
        public required string LifeAssuredState { get; set; }

        // Nominee Details
        public required string Nominee { get; set; }
        public required DateTime NomineeDob { get; set; }
        public string? NomineePan { get; set; }
        public required string NomineeAadhar { get; set; }
        public required string NomineeGender { get; set; }

        public string? NomineePhone { get; set; }
        public string? NomineeEmail { get; set; }
        public required string NomineeAddress { get; set; }
        public required string NomineeDistrict { get; set; }
        public required string NomineePincode { get; set; }
        public required string NomineeState { get; set; }

        public string? Appointee { get; set; }
        public DateTime? AppointeeDob { get; set; }
        public string? AppointeePan { get; set; }
        public string? AppointeeAadhar { get; set; }
        public string? AppointeeGender { get; set; }

        public string? AppointeePhone { get; set; }
        public string? AppointeeEmail { get; set; }
        public string? AppointeeAddress { get; set; }
        public string? AppointeeDistrict { get; set; }
        public string? AppointeePincode { get; set; }
        public string? AppointeeState { get; set; }
        public string? CustomerType { get; set; }
    }
}
