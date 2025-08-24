namespace ce.imf.connect.comon.DTOs
{
    public class PcDetailsDto
    {
        public Guid Id { get; set; }
        public string ApplicationNo { get; set; } = string.Empty;
        public Guid SourcingId { get; set; }
        public decimal? PcCommAmt { get; set; }
        public decimal? TdsAmount { get; set; }
        public decimal? AmtClaimed { get; set; }
        public decimal? AmtReceived { get; set; }
        public decimal? PcPending { get; set; }

        // audit
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
