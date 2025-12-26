namespace AT.UFTMS.WebAPI.Application.Queries.Tickets;
public interface ITicketReadRepository
{
    IReadOnlyList<Models.TicketReadModel> GetByUserId(Guid userId);
    
    Models.TicketReadModel? GetById(Guid id);
}