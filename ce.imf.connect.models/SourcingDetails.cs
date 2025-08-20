
namespace ce.imf.connect.models
{
    public class SourcingDetails:BaseModel
    {
        public required string Fy { get; set; }
        public required string SourceNumber { get; set; }
        public required int Year { get; set; }
        public required string LoginMonth { get; set; }
        public required string PremiumMonth { get; set; }
        public required string Location { get; set; }
        public required string Department { get; set; }
        public required string InsuranceHead { get; set; }
        public required string BusinessHead { get; set; }
        public required string Presentator { get; set; }
        public required string BusinessPartner { get; set; }
        public required string InsuranceCategory { get; set; }
        public required string FreshRenewal { get; set; }
        public required string PrincipalCo { get; set; }
        public required string PlanType { get; set; }
        public required string EmpCode { get; set; }
        public required string ApplicationNo { get; set; }
    }

}
