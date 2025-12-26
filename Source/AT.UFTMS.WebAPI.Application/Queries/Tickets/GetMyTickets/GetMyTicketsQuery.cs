namespace AT.UFTMS.WebAPI.Application.Queries.Tickets.GetMyTickets;
public sealed class GetMyTicketsQuery(ITicketReadRepository repository,
                                      Abstractions.Services.ICurrentUserService currentUser,
                                      Specifications.TicketReadSpecification specification)
{
    public IReadOnlyList<Models.TicketReadModel> Execute(GetMyTicketsQueryRequest request)
    {
        IReadOnlyList<Models.TicketReadModel> tickets = repository.GetByUserId(currentUser.UserId);

        return tickets
               .Where(t => specification.IsSatisfiedBy(t, request))
               .Skip(request.Skip)
               .Take(request.PageSize)
               .ToList();
    }
}