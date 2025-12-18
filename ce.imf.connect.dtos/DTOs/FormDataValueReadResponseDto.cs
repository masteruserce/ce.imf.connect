namespace ce.imf.connect.common.DTOs
{
    public class FormDataValueReadResponseDto
    {
        public Guid Id { get; set; }
        public string? TransactionId { get; set; }
        public Guid? ClientId { get; set; }
        public string? FormName { get; set; }
        public Guid FormId { get; set; }
        public string? SectionName { get; set; }
        public Guid SectionId { get; set; }
        public string? FieldName { get; set; }
        public Guid FieldId { get; set; }
        public string? DataValue { get; set; }
        public bool Active { get; set; }
        public bool IsDraft { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }

}