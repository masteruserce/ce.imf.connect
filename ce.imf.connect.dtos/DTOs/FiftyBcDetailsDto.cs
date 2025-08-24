namespace ce.imf.connect.comon.DTOs
{
    public class FiftyBcDetailsDto
    {
        public Guid Id { get; set; }
        public string ApplicationNo { get; set; } = string.Empty;
        public Guid SourcingId { get; set; }
        public decimal? FiftyBcPcAmt { get; set; }
        public decimal? TdsAmount { get; set; }
        public decimal? AmountClaimed { get; set; }
        public decimal? AmountReceived { get; set; }
        public decimal? FiftyBcPcPending { get; set; }

        // audit
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
