using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MillionRealStateCompany.Application.Interfaces;
using MillionRealStateCompany.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MillionRealStateCompany.Application.Service
{
    public class TokenService(IConfigurationRoot appConfiguration) : ITokenService
    {
        public string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appConfiguration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Rol),

             }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = appConfiguration["Jwt:Issuer"], 
                Audience = appConfiguration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
