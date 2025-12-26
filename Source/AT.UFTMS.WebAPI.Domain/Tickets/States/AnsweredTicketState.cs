namespace AT.UFTMS.WebAPI.Domain.Tickets.States;
public class AnsweredTicketState
    : ITicketState
{
    Enums.TicketStatus ITicketState.Status => Enums.TicketStatus.Answered;

    void ITicketState.StartProgress(Entities.Ticket ticket)
    {
        throw new Exceptions.DomainException("Answered ticket cannot be restarted.");
    }

    void ITicketState.Answer(Entities.Ticket ticket)
    {
        throw new Exceptions.DomainException("Ticket already answered.");
    }

    void ITicketState.Close(Entities.Ticket ticket)
    {
        ticket.SetState(new ClosedTicketState());
    }
}