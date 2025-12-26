namespace AT.UFTMS.WebAPI.Domain.Tickets.States;
public interface ITicketState
{
    Enums.TicketStatus Status { get; }

    void StartProgress(Entities.Ticket ticket);
    void Answer(Entities.Ticket ticket);
    void Close(Entities.Ticket ticket);
}