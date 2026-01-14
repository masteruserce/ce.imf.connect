namespace ce.imf.connect.comon.DTOs
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool Active { get; set; }
        public List<UserMenuDto> Menus { get; set; } = new();
    }
}
