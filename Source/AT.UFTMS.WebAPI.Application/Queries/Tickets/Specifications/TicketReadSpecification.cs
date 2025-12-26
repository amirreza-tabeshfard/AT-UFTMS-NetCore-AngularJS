namespace AT.UFTMS.WebAPI.Application.Queries.Tickets.Specifications;
public sealed class TicketReadSpecification
{
    public bool IsSatisfiedBy(Models.TicketReadModel ticket, GetMyTickets.GetMyTicketsQueryRequest request)
    {
        if ((request.Status is not null) && (ticket.Status != request.Status.ToString()))
            return false;

        return true;
    }
}