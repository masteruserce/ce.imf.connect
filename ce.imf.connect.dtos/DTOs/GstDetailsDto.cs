namespace ce.imf.connect.comon.DTOs
{
    public class GstDetailsDto
    {
        public Guid Id { get; set; }
        public string ApplicationNo { get; set; } = string.Empty;
        public Guid SourcingId { get; set; }
        public decimal? Gst18 { get; set; }
        public decimal? GstReceived { get; set; }
        public decimal? PendingGst { get; set; }

        // audit
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
