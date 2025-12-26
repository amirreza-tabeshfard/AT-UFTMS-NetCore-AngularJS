namespace AT.UFTMS.WebAPI.Application.Abstractions.Services;
public interface IAuthService
{
    string GenerateToken(Guid userId, string username);
}