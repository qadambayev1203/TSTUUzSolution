using Entities.DTO;
using Entities.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TSTUWebAPI.Services;

public class TokenServices
{
    private readonly IOptions<AppSettings> appSettings;
    private readonly JwtSecurityTokenHandler securityTokenHandler;

    public TokenServices(IOptions<AppSettings> appSettings)
    {
        this.appSettings = appSettings;
        this.securityTokenHandler = new JwtSecurityTokenHandler();
    }

    public string CreateToken(User user)
    {
        try
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Value.SecretKey);
            var tokenDescriptoir = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim("UserId", user.id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.login.ToString()),
                        new Claim(ClaimTypes.Role, user.user_type_.type.ToString()),
                    }
                   ),
                Expires = DateTime.UtcNow.AddDays(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var securityToken = securityTokenHandler.CreateToken(tokenDescriptoir);
            return securityTokenHandler.WriteToken(securityToken);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
