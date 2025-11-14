using System.Security.Claims;
using System.Text.Json;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using schoolattendance_api.Dtos.User;

namespace schoolattendance_api.Services.Auth
{
    public class JwtTokenService : IJwtTokenService
    {
        private string _secretKey;
        public int timeHours { get; }

        public JwtTokenService(string secretKey)
        {
            _secretKey = secretKey;
            timeHours = 1;
        }

        public string GenerateToken(UserDto authDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var byteKey = Encoding.UTF8.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim("User", JsonSerializer.Serialize(authDto))
            }),
                Expires = DateTime.UtcNow.AddHours(timeHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey),
                                                                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}