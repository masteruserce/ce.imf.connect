namespace ce.imf.connect.common.DTOs
{
    public class FormDataValueDto
    {
        public Guid Id { get; set; }
        public Guid? ClientId { get; set; }
        public Guid FormId { get; set; }
        public Guid SectionId { get; set; }
        public Guid FieldId { get; set; }
        public string? DataValue { get; set; }
        public bool Active { get; set; }
    }

}