using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GalleryAPI.BLL.Services.Interfaces;
using GalleryAPI.DAL.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GalleryAPI.BLL.Services;

public class JwtService(IOptions<JwtOptions> jwtOptions) : IJwtService
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public string GenerateJwt(int userId, string username, List<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString())
        };
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role,role)));

       
        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience : _jwtOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key)), 
                SecurityAlgorithms.HmacSha512Signature));

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}