namespace AT.UFTMS.WebAPI.Application.Queries.Tickets.GetMyTickets;
public sealed class GetMyTicketsQueryRequest 
    : Common.PagedQuery
{
    public Domain.Enums.TicketStatus? Status { get; init; }

    public Domain.Enums.TicketPriority? Priority { get; init; }
}