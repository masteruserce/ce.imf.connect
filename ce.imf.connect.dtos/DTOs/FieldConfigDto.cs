namespace ce.imf.connect.comon.DTOs
{
    public class FieldConfigDto
    {
        public Guid Id { get; set; }
        public Guid? ClientId { get; set; }
        public Guid SectionId { get; set; }
        public string FieldName { get; set; } = string.Empty;
        public int FieldOrder { get; set; }
        public string Type { get; set; } = "text";
        public string Label { get; set; } = string.Empty;
        public string Placeholder { get; set; } = string.Empty;
        public string Options { get; set; } = string.Empty;
        public bool Required { get; set; }
        public string ValidationMessage { get; set; } = string.Empty;
        public string DefaultValue { get; set; } = string.Empty;
    }
}
