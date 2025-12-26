namespace AT.UFTMS.WebAPI.Api.Authentication;
public class JwtAuthService(JwtOptions options)
    : Application.Abstractions.Services.IAuthService
{
    private readonly JwtOptions _options = options;

    public string GenerateToken(Guid userId, string username)
    {
        System.Security.Claims.Claim[] claims = new[]
        {
            new System.Security.Claims.Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, userId.ToString()),
            new System.Security.Claims.Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.UniqueName, username)
        };

        Microsoft.IdentityModel.Tokens.SymmetricSecurityKey key = new(System.Text.Encoding.UTF8.GetBytes(_options.SecretKey));
        Microsoft.IdentityModel.Tokens.SigningCredentials credentials = new(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);
        
        System.IdentityModel.Tokens.Jwt.JwtSecurityToken token = new(issuer: _options.Issuer,
                                                                     audience: _options.Audience,
                                                                     claims: claims,
                                                                     expires: DateTime.UtcNow.AddMinutes(_options.ExpirationMinutes),
                                                                     signingCredentials: credentials);

        return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
    }
}