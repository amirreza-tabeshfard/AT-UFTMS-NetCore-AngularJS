namespace AT.UFTMS.WebAPI.Application.Abstractions.Repositories;
public interface ITicketRepository
{
    Domain.Entities.Ticket? GetById(Guid id);

    IReadOnlyList<Domain.Entities.Ticket> GetByUserId(Guid userId);

    void Add(Domain.Entities.Ticket ticket);

    void Update(Domain.Entities.Ticket ticket);
}