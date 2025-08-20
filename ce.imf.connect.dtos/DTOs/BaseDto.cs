namespace ce.imf.connect.comon.DTOs
{
    public class BaseDto
    {
        public Guid? Id { get; set; }
        public string? ItemType { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
