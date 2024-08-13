using Entities.DTO;
using Entities.Model.AnyClasses;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TSTUWebAPI.AnyMiddleware;

public class TokenMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public TokenMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _configuration = configuration;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer ") && authorizationHeader != SessionClass.tokenCheck)
            {
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(s: _configuration["AppSettings:SecretKey"]);

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                int user_id = Convert.ToInt32(principal.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value);
                if (user_id != 0)
                {
                    SessionClass.id = user_id;
                    SessionClass.token = $"Bearer {token}";
                }

            }
        }
        catch { }

        await _next(context);
    }
}
