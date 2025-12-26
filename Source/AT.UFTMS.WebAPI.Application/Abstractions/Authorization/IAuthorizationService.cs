namespace AT.UFTMS.WebAPI.Application.Abstractions.Authorization;
public interface IAuthorizationService
{
    void EnsureUserIsTicketOwner(Guid ticketOwnerId);

    void EnsureUserIsAdmin();
}