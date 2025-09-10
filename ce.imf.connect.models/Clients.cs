using System;
namespace ce.imf.connect.models
{
    public class Clients
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? LogoBase64 { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Form>? Forms { get; set; }
        public ICollection<Section>? Sections { get; set; }
        public ICollection<FieldConfig>? FieldConfigs { get; set; }
    }

}
