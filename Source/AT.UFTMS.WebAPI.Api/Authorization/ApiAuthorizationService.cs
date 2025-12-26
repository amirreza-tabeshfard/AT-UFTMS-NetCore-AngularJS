namespace AT.UFTMS.WebAPI.Api.Authorization;
public class ApiAuthorizationService(Application.Abstractions.Services.ICurrentUserService currentUserService,
                                     IHttpContextAccessor httpContextAccessor)
    : Application.Abstractions.Authorization.IAuthorizationService
{
    public void EnsureUserIsTicketOwner(Guid ticketOwnerId)
    {
        if (currentUserService.UserId != ticketOwnerId)
            throw new UnauthorizedAccessException("You are not the owner of this ticket.");
    }

    public void EnsureUserIsAdmin()
    {
        bool isAdmin = httpContextAccessor.HttpContext?
            .User
            .IsInRole("Admin") ?? false;

        if (!isAdmin)
            throw new UnauthorizedAccessException("Admin access required.");
    }
}