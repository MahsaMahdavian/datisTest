using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ConvertLinqApplication.Classes;
using ConvertLinqApplication.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;


namespace ConvertLinqApplication.Services
{
    //public class jwtService:IjwtService
    //{
    //    private readonly SignInManager<User> _signInManager;
    //    public readonly SiteSettings _siteSettings;
    //    public jwtService(IOptionsSnapshot<SiteSettings> siteSettings, SignInManager<User> signInManager)
    //    {
    //        _siteSettings = siteSettings.Value;
    //        _signInManager = signInManager;
    //    }
    //    public async Task<string> GenerateToken(User user)
    //    {
    //        var SecretKey = Encoding.UTF8.GetBytes(_siteSettings.JwtSettings.SecretKey);
    //        var SighningCredentials = new SigningCredentials(new SymmetricSecurityKey(SecretKey), SecurityAlgorithms.HmacSha256Signature);

    //        var encryptionkey = Encoding.UTF8.GetBytes(_siteSettings.JwtSettings.EncrypKey); //must be 16 character
    //        var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

    //        var TokenDescriptor = new SecurityTokenDescriptor()
    //        {

    //            Issuer = _siteSettings.JwtSettings.Issuer,
    //            Audience = _siteSettings.JwtSettings.Audience,
    //            IssuedAt = DateTime.Now,
    //            NotBefore = DateTime.Now.AddMinutes(_siteSettings.JwtSettings.NotBeforeMinutes),
    //            Expires = DateTime.Now.AddMinutes(_siteSettings.JwtSettings.ExpirationMinutes),
    //            SigningCredentials = SighningCredentials,
    //            Subject = new ClaimsIdentity(await GetClaimsAsync(user)),
    //        };

    //        var tokenHandler = new JwtSecurityTokenHandler();
    //        var securityToken = tokenHandler.CreateToken(TokenDescriptor);
    //        return tokenHandler.WriteToken(securityToken);

    //    }


    //    public async Task<IEnumerable<Claim>> GetClaimsAsync(User user)
    //    {
    //        var result = await _signInManager.ClaimsFactory.CreateAsync(user);
    //        var list = new List<Claim>(result.Claims);
    //        list.Add(new Claim(ClaimTypes.MobilePhone, "09355854104"));
    //        return list;
    //        //var claims = new List<Claim>()
    //        //{
    //        //    new Claim(ClaimTypes.Name,"Mahsa"),
    //        //    new Claim(ClaimTypes.NameIdentifier,"58"),
    //        //    new Claim (ClaimTypes.MobilePhone,"09355854104"),
    //        //    new Claim("securityStampClaimType","5560264091"),
    //        //    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
    //        //    new Claim (ClaimTypes.Role,"کاربر")
    //        //};
    //        //return claims;

    //    }
    //}
}
