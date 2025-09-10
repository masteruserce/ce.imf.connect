namespace ce.imf.connect.comon.DTOs
{
    public class ImportFieldsRequest
    {
        public Guid? ClientId { get; set; }          // optional
        public string FormName { get; set; } = string.Empty; // must be provided
        public List<SectionDto> Sections { get; set; } = new();
    }
}
