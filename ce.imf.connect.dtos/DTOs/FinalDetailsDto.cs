namespace ce.imf.connect.comon.DTOs
{
    public class FinalDetailsDto
    {
        public Guid Id { get; set; }
        public string ApplicationNo { get; set; } = string.Empty;
        public Guid SourcingId { get; set; }
        public decimal? TotalCommAmt { get; set; }
        public decimal? TotalCommissionReceived { get; set; }
        public decimal? BaseCommAmt { get; set; }
        public decimal? TdsAmount { get; set; }
        public decimal? AmtClaimed { get; set; }
        public decimal? AmtReceived { get; set; }
        public decimal? BasePending { get; set; }

        // audit
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
