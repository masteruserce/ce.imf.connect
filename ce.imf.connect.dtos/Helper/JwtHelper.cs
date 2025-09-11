using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ce.imf.connect.common.Helpers
{
    public class JwtHelper
    {
        public static (string token, DateTime expiry) GenerateToken(Guid clientId, string userName, string userPasswordHash)
        {
            // 🔑 Generate signing key from password hash + suffix
            var secretKey = userPasswordHash + "ce.imf.connect.users";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiry = DateTime.UtcNow.AddMinutes(60); // can be configurable later

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim("clientId", clientId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "ce.imf.connect",
                audience: "ce.imf.connect.users",
                claims: claims,
                expires: expiry,
                signingCredentials: creds
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), expiry);
        }
    }
}
