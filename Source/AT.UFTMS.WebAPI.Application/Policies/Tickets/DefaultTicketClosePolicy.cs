namespace AT.UFTMS.WebAPI.Application.Policies.Tickets;
public class DefaultTicketClosePolicy 
    : ITicketClosePolicy
{
    public void Validate(Domain.Entities.Ticket ticket)
    {
        if (ticket.Status == Domain.Enums.TicketStatus.New)
            throw new InvalidOperationException("New ticket cannot be closed directly.");

        if (ticket.Status == Domain.Enums.TicketStatus.Closed)
            throw new InvalidOperationException("Ticket is already closed.");
    }
}