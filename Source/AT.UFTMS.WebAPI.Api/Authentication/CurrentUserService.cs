namespace AT.UFTMS.WebAPI.Api.Authentication;
public class CurrentUserService(IHttpContextAccessor httpContextAccessor)
        : Application.Abstractions.Services.ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Guid UserId
    {
        get
        {
            /*
            HttpContext httpContext = _httpContextAccessor.HttpContext
                ?? throw new InvalidOperationException("HttpContext is not available.");

            ClaimsPrincipal? user = httpContext?.User;

            if (user is null || !user.Identity!.IsAuthenticated)
                throw new UnauthorizedAccessException("User is not authenticated.");

            var claim = user.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)
                        ?? throw new UnauthorizedAccessException("UserId claim not found.");

            return Guid.Parse(claim.Value);
            */

            return Guid.NewGuid();
        }
    }

}