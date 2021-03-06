using Microsoft.IdentityModel.Tokens;
using Spending.Domain;
using Spending.Token.Security;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Spending.Token.Service
{
    public class TokenService
    {
        public static string GenerateToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecurityConsts.AudienceSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Login.ToString())
                }),
                Issuer = SecurityConsts.Issuer,
                Expires = DateTime.UtcNow.AddHours(SecurityConsts.AccessTokenExpireHours),
                Audience = SecurityConsts.AudienceId,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
