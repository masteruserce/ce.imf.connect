using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.Helpers;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Helper;
using ce.imf.connect.infra.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.application.Service.Catalog
{
    public class AuthService: IAuthService 
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserRepository _userRepository;
        public AuthService(IClientRepository clientRepository, IUserRepository userRepository)
        {
                _clientRepository = clientRepository;
            _userRepository = userRepository;
        }
        public async Task<ImfResponse<AuthResponse>> AuthenticateAsync(AuthRequest request)
        {
            var user = await  _userRepository.GetByUserNameAsync(request.UserName);

            if (user == null || !HashHelper.VerifyPassword(request.Password, user.PasswordHash))
            {
                return new ImfResponse<AuthResponse>(
                    new List<ImfErrors> { new ImfErrors { Code = "401", Details = "Invalid credentials" } },
                    "Invalid username or password"
                );
            }

            if (!user.Active) // ✅ check if client is active
            {
                return new ImfResponse<AuthResponse>(
                    new List<ImfErrors> { new ImfErrors { Code = "403", Details = "Inactive client" } },
                    "User is not active"
                );
            }

            // 🔑 Use client’s hashed password as signing key
            var (token, expiry) = JwtHelper.GenerateToken(user.ClientId, user.UserName, user.PasswordHash);

            var response = new AuthResponse
            {
                ClientId = user.ClientId,
                Token = token,
                Expiry = expiry,
                UserType = user.Role,
                UserName = user.UserName
            };

            return new ImfResponse<AuthResponse>(response, "Authentication successful");
        }

    }
}
