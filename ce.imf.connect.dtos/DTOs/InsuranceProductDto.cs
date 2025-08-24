namespace ce.imf.connect.comon.DTOs
{
    public class InsuranceProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string Term { get; set; } = string.Empty;
        public string PaymentTerm { get; set; } = string.Empty;
        public string PaymentMode { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
