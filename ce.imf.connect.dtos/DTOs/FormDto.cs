namespace ce.imf.connect.comon.DTOs
{
    public class FormDto
    {
        public Guid Id { get; set; }
        public Guid? ClientId { get; set; }
        public string FormName { get; set; } = string.Empty;
        public List<SectionDto> Sections { get; set; } = new();
    }
}
