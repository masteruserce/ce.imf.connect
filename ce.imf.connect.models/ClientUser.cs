using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class ClientUser
    {
        public Guid UserId { get; set; }
        public Guid ClientId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Reader";
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<UserMenu> Menus { get; set; } = new List<UserMenu>();
    }
}
