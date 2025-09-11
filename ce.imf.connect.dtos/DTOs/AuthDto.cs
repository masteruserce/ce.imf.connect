using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class AuthRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class AuthResponse
    {
        public Guid ClientId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
    }
}
