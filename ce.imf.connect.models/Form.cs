namespace ce.imf.connect.models
{
    public class Form
    {
        public Guid Id { get; set; }
        public Guid? ClientId { get; set; }
        public string FormName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Client? Client { get; set; }
        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}
