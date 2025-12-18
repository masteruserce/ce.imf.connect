using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.DTOs
{
    public class CreateUserRequest
    {
        public Guid ClientId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "Reader";
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public List<UserMenuDto> Menus { get; set; } = new();
    }
}
