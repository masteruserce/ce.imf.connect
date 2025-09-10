namespace ce.imf.connect.models
{
    public class Section
    {
        public Guid Id { get; set; }
        public Guid? ClientId { get; set; }
        public Guid FormId { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public int DisplayOrder { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Form? Form { get; set; }
        public Client? Client { get; set; }
        public ICollection<FieldConfig> Fields { get; set; } = new List<FieldConfig>();
    }
}
