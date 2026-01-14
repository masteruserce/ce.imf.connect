using ce.imf.connect.comon.DTOs;
namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IUserService
    {
        Task<ImfResponse<UserDto>> CreateUserAsync(CreateUserRequest request);
        Task<ImfResponse<UserDto>> UpdateUserAsync(UserDto dto);
        Task<ImfResponse<bool>> ChangePasswordAsync(Guid userId, string newPassword);
        Task<ImfResponse<IEnumerable<UserDto>>> GetUsersByClientAsync(Guid clientId);
    }

}
