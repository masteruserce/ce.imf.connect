using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;


namespace ce.imf.connect.common.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToDto(this ClientUser entity)
        {
            return new UserDto
            {
                UserId = entity.UserId,
                UserName = entity.UserName,
                Role = entity.Role,
                CanRead = entity.CanRead,
                CanWrite = entity.CanWrite,
                Active = entity.Active,
                Menus = entity.Menus.Select(m => new UserMenuDto
                {
                    MenuName = m.MenuName,
                    Visible = m.Visible
                }).ToList()
            };
        }

        public static ClientUser ToEntity(this CreateUserRequest request)
        {
            return new ClientUser
            {
                UserId = Guid.NewGuid(),
                ClientId = request.ClientId,
                UserName = request.UserName,
                PasswordHash = request.Password,
                Role = request.Role,
                CanRead = request.CanRead,
                CanWrite = request.CanWrite,
                Active = true,
                Menus = request.Menus.Select(m => new UserMenu
                {
                    UserMenuId = Guid.NewGuid(),
                    MenuName = m.MenuName,
                    Visible = m.Visible
                }).ToList()
            };
        }
    }

}
