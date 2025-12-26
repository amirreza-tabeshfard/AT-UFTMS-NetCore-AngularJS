namespace AT.UFTMS.WebAPI.Application.Queries.Tickets.Models;
public sealed class TicketReadModel
{
    public Guid Id { get; init; }
    public string Title { get; init; } = null!;
    public string Description { get; init; } = null!;
    public string Status { get; init; } = null!;
    public DateTime CreatedAt { get; init; }
}