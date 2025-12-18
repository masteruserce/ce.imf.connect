using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.models
{
    public class UserMenu
    {
        public Guid UserMenuId { get; set; }
        public Guid UserId { get; set; }
        public string MenuName { get; set; } = string.Empty;
        public bool Visible { get; set; }
    }
}
