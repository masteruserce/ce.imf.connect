namespace ce.imf.connect.comon.DTOs
{
    public class SectionDto
    {
        public Guid? Id { get; set; }
        public Guid? ClientId { get; set; }
        public Guid? FormId { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public List<FieldConfigDto> Fields { get; set; } = new();
    }
}
