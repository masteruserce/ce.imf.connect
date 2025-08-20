namespace ce.imf.connect.comon.DTOs
{
    public class LeadDto
    {
        public required string Proposer { get; set; }
        public required DateTime ProposerDob { get; set; }
        public required string ProposerPan { get; set; }
        public required string ProposerAadhar { get; set; }

        public required string LifeAssured { get; set; }
        public required DateTime LifeAssuredDob { get; set; }
        public required string LifeAssuredPan { get; set; }
        public required string LifeAssuredAadhar { get; set; }

        public string? Nominee { get; set; }
        public DateTime? NomineeDob { get; set; }
        public string? NomineePan { get; set; }
        public string? NomineeAadhar { get; set; }
        public string? NomineePhone { get; set; }

        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string District { get; set; }
        public required string Pincode { get; set; }
        public required string State { get; set; }
    }
}
