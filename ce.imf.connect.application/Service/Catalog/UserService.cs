using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.Mapper;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Helper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using System.Net;

namespace ce.imf.connect.application.Service.Catalog
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<ImfResponse<UserDto>> CreateUserAsync(CreateUserRequest request)
        {
            var ecxistingUser = await _repo.GetByUserNameAsync(request.UserName);
            if (ecxistingUser != null)
            {
                return new ImfResponse<UserDto>(
                   new List<ImfErrors> { new ImfErrors { Code = HttpStatusCode.BadRequest.ToString(), Details = $"User Name {request.UserName} is already taken, please choose a different user name", Trace = "" } });

            }
            // Hash password before saving
            request.Password = request.Password.HashPassword();

            var user = request.ToEntity();
            var saved = await _repo.AddAsync(user);

            return new ImfResponse<UserDto>(saved.ToDto(), "User created successfully");
        }

        public async Task<ImfResponse<UserDto>> UpdateUserAsync(UserDto dto)
        {
            var existing = await _repo.GetByIdAsync(dto.UserId);
            if (existing == null)
            {
                return new ImfResponse<UserDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "User not found" } },
                    "User not found"
                );
            }

            existing.UserName = dto.UserName;
            existing.Role = dto.Role;
            existing.CanRead = dto.CanRead;
            existing.CanWrite = dto.CanWrite;
            existing.Active = dto.Active;

            // update menus
            existing.Menus = dto.Menus.Select(m => new UserMenu
            {
                UserMenuId = Guid.NewGuid(),
                UserId = existing.UserId,
                MenuName = m.MenuName,
                Visible = m.Visible
            }).ToList();

            await _repo.UpdateAsync(existing);
            return new ImfResponse<UserDto>(existing.ToDto(), "User updated successfully");
        }

        public async Task<ImfResponse<bool>> ChangePasswordAsync(Guid userId, string newPassword)
        {
            var user = await _repo.GetByIdAsync(userId);
            if (user == null)
            {
                return new ImfResponse<bool>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "User not found" } },
                    "User not found"
                );
            }

            user.PasswordHash = user.PasswordHash.HashPassword();
            await _repo.UpdateAsync(user);

            return new ImfResponse<bool>(true, "Password changed successfully");
        }

        public async Task<ImfResponse<IEnumerable<UserDto>>> GetUsersByClientAsync(Guid clientId)
        {
            var users = await _repo.GetByClientAsync(clientId);
            return new ImfResponse<IEnumerable<UserDto>>(users.Select(u => u.ToDto()), "Fetched users successfully");
        }

        public async Task<ImfResponse<bool>> DeleteUserAsync(Guid userId)
        {
            await _repo.DeleteAsync(userId);
            return new ImfResponse<bool>(true, "User deactivated successfully");
        }
    }

}
