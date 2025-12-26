namespace AT.UFTMS.WebAPI.Domain.Tickets.States;
public class InProgressTicketState : ITicketState
{
    Enums.TicketStatus ITicketState.Status => Enums.TicketStatus.InProgress;

    void ITicketState.StartProgress(Entities.Ticket ticket)
    {
        throw new Exceptions.DomainException("Ticket already in progress.");
    }

    void ITicketState.Answer(Entities.Ticket ticket)
    {
        ticket.SetState(new AnsweredTicketState());
    }

    void ITicketState.Close(Entities.Ticket ticket)
    {
        ticket.SetState(new ClosedTicketState());
    }
}