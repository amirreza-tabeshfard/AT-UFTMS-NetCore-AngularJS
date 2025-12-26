namespace AT.UFTMS.WebAPI.Application.Policies.Tickets;
public interface ITicketClosePolicy
{
    void Validate(Domain.Entities.Ticket ticket);
}