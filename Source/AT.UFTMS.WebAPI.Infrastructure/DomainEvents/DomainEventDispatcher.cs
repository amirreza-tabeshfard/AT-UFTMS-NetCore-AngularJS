using Microsoft.Extensions.DependencyInjection;

namespace AT.UFTMS.WebAPI.Infrastructure.DomainEvents;
public class DomainEventDispatcher(IServiceProvider serviceProvider)
    : Application.Common.IDomainEventDispatcher
{
    public async Task DispatchAsync(IEnumerable<Domain.Common.IDomainEvent> domainEvents,
                                    CancellationToken cancellationToken)
    {
        foreach ((Domain.Common.IDomainEvent domainEvent, Type handlerType, Object handler) in from Domain.Common.IDomainEvent domainEvent in domainEvents
                                                                                               let handlerType = typeof(Application.Common.IDomainEventHandler<>).MakeGenericType(domainEvent.GetType())
                                                                                               let handlers = serviceProvider.GetServices(handlerType)
                                                                                               from object handler in handlers
                                                                                               select (domainEvent, handlerType, handler))
        {
            await ((Task)handlerType
                  .GetMethod("HandleAsync")!
                  .Invoke(handler, new object[] { domainEvent, cancellationToken })!);
        }
    }
}