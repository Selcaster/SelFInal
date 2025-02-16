using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Musico.BL.Constants;
using Musico.BL.DTOs.Options;
using Musico.BL.ExternalServices.Interfaces;
using Musico.Core.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Musico.Core.Entities;
namespace Musico.BL.ExternalServices.Implements;

public class JwtTokenHandler:IJwtTokenHandler
{
    readonly JwtOptions opt;
    public JwtTokenHandler(IOptions<JwtOptions> _opt)
    {
        opt = _opt.Value;
    }
    public string CreateToken(User user, int hours = 36)
    {
        List<Claim> claims = [
            new Claim(ClaimType.Username, user.Username),
            new Claim(ClaimType.Email, user.Email),
            new Claim(ClaimType.Role,user.Role.ToString()),
            new Claim(ClaimType.Id,user.Id.ToString()),
        ];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(opt.SecretKey));
        SigningCredentials cred = new(key, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken secToken = new(
            issuer: opt.Issuer,
            audience: opt.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddHours(hours),
            signingCredentials: cred
        );
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(secToken);
    }
}