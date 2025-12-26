namespace AT.UFTMS.WebAPI.Domain.Tickets.States;
public class ClosedTicketState : ITicketState
{
    Enums.TicketStatus ITicketState.Status => Enums.TicketStatus.Closed;

    void ITicketState.StartProgress(Entities.Ticket ticket)
    {
        throw new Exceptions.DomainException("Closed ticket cannot be modified.");
    }

    void ITicketState.Answer(Entities.Ticket ticket)
    {
        throw new Exceptions.DomainException("Closed ticket cannot be modified.");
    }

    void ITicketState.Close(Entities.Ticket ticket)
    {
        throw new Exceptions.DomainException("Ticket already closed.");
    }
}