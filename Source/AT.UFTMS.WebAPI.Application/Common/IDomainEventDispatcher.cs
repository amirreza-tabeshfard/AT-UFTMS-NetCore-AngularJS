namespace AT.UFTMS.WebAPI.Application.Common;
public interface IDomainEventDispatcher
{
    Task DispatchAsync(IEnumerable<Domain.Common.IDomainEvent> domainEvents, CancellationToken cancellationToken);
}