using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;


namespace ConvertLinqApplication.Services
{
    public class jwtService:IjwtService
    {
        public async Task<string> GenerateToken()
        {
            var SecretKey = Encoding.UTF8.GetBytes("MahsaMahdavi1641372");
            var SighningCredentials = new SigningCredentials(new SymmetricSecurityKey(SecretKey), SecurityAlgorithms.HmacSha256Signature);

            var TokenDescriptor = new SecurityTokenDescriptor()
            {

                Issuer = "Mahsa",
                Audience = "AllCopanies",
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = SighningCredentials,
                Subject = new ClaimsIdentity(await GetClaimsAsync()),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(TokenDescriptor);
            return tokenHandler.WriteToken(securityToken);

        }


        public async Task<IEnumerable<Claim>> GetClaimsAsync()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Mahsa"),
                new Claim(ClaimTypes.NameIdentifier,"58"),
                new Claim (ClaimTypes.MobilePhone,"09355854104"),
                new Claim("securityStampClaimType","5560264091"),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim (ClaimTypes.Role,"کاربر")
            };
            return claims;

        }
    }
}
