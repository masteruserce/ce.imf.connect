namespace ce.imf.connect.models
{
    public class PlanPremiumDetails
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string PlanName { get; set; } = string.Empty;

        // Foreign Keys
        public string ApplicationNo { get; set; } = string.Empty;
        public Guid SourcingId { get; set; }

        public string? PolicyNo { get; set; }
        public int? PaymentTerm { get; set; }
        public int? PaymentPayingTerm { get; set; }
        public decimal? SumAssured { get; set; }
        public string? PremiumPayingMode { get; set; }
        public decimal? ChequeAmount { get; set; }
        public decimal? ModelPremium { get; set; }
        public decimal? Wrp { get; set; }
        public decimal? Wapi { get; set; }
        public decimal? IssuedWrp { get; set; }

        // Navigation Property
        public SourcingDetails? SourcingDetails { get; set; }
    }

}
