namespace AT.UFTMS.WebAPI.Domain.Tickets.States;
public class NewTicketState : ITicketState
{
    Enums.TicketStatus ITicketState.Status => Enums.TicketStatus.New;

    void ITicketState.StartProgress(Entities.Ticket ticket)
    {
        ticket.SetState(new InProgressTicketState());
    }

    void ITicketState.Answer(Entities.Ticket ticket)
    {
        throw new Exceptions.DomainException("Cannot answer a new ticket.");
    }

    void ITicketState.Close(Entities.Ticket ticket)
    {
        ticket.SetState(new ClosedTicketState());
    }
}