using Microsoft.Extensions.Logging;

namespace AT.UFTMS.WebAPI.Application.EventHandlers.Tickets;
public class TicketClosedEventHandler(ILogger<TicketClosedEventHandler> logger)
    : Common.IDomainEventHandler<Domain.Events.TicketClosedDomainEvent>
{
    public Task HandleAsync(Domain.Events.TicketClosedDomainEvent domainEvent,
                            CancellationToken cancellationToken)
    {
        logger.LogInformation("Ticket {TicketId} closed by user {UserId} at {OccurredOn}",
                              domainEvent.TicketId,
                              domainEvent.ClosedByUserId,
                              domainEvent.OccurredOn);

        return Task.CompletedTask;
    }
}