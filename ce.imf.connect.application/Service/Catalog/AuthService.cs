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
        public AuthService(IClientRepository clientRepository)
        {
                _clientRepository = clientRepository;
        }
        public async Task<ImfResponse<AuthResponse>> AuthenticateAsync(AuthRequest request)
        {
            var client = await _clientRepository.GetByUsernameAsync(request.UserName);

            if (client == null || !HashHelper.VerifyPassword(request.Password, client.UserPassword))
            {
                return new ImfResponse<AuthResponse>(
                    new List<ImfErrors> { new ImfErrors { Code = "401", Details = "Invalid credentials" } },
                    "Invalid username or password"
                );
            }

            if (!client.IsActive) // ✅ check if client is active
            {
                return new ImfResponse<AuthResponse>(
                    new List<ImfErrors> { new ImfErrors { Code = "403", Details = "Inactive client" } },
                    "Client is not active"
                );
            }

            // 🔑 Use client’s hashed password as signing key
            var (token, expiry) = JwtHelper.GenerateToken(client.ClientId, client.UserName, client.UserPassword);

            var response = new AuthResponse
            {
                ClientId = client.ClientId,
                Token = token,
                Expiry = expiry
            };

            return new ImfResponse<AuthResponse>(response, "Authentication successful");
        }

    }
}
