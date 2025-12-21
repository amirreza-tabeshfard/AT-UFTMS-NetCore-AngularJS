namespace AT.UFTMS.WebAPI.Application.Abstractions.Services;
public interface ICurrentUserService
{
    Guid UserId { get; }
}