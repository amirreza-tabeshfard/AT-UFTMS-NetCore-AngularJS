namespace AT.UFTMS.WebAPI.Application.Common;
public interface IDomainEventHandler<in TDomainEvent>
    where TDomainEvent 
    : Domain.Common.IDomainEvent
{
    Task HandleAsync(TDomainEvent domainEvent, CancellationToken cancellationToken);
}