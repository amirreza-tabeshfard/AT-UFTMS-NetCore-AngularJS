namespace AT.UFTMS.WebAPI.Domain.Events;
public sealed class TicketClosedDomainEvent(Guid ticketId,
                                            Guid closedByUserId)
    : Common.IDomainEvent
{
    public Guid TicketId { get; } = ticketId;

    public Guid ClosedByUserId { get; } = closedByUserId;

    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}