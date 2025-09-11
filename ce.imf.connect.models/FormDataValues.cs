namespace ce.imf.connect.models
{
    public class FormDataValue
    {
        public Guid Id { get; set; }
        public Guid? ClientId { get; set; }
        public Guid FormId { get; set; }
        public Guid SectionId { get; set; }
        public Guid FieldId { get; set; }
        public string? DataValue { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

}
