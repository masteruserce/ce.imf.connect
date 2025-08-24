namespace ce.imf.connect.comon.DTOs
{
    public class TotalDetailsDto
    {
        public Guid Id { get; set; }
        public string ApplicationNo { get; set; } = string.Empty;
        public Guid SourcingId { get; set; }
        public decimal? TotalReceivable { get; set; }
        public decimal? TotalReceived { get; set; }
        public decimal? PendingTotal { get; set; }

        // audit
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
