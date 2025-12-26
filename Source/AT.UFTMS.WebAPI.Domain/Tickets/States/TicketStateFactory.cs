namespace AT.UFTMS.WebAPI.Domain.Tickets.States;
public static class TicketStateFactory
{
    public static ITicketState Create(Enums.TicketStatus status) =>
        status switch
        {
            Enums.TicketStatus.New => new NewTicketState(),
            Enums.TicketStatus.InProgress => new InProgressTicketState(),
            Enums.TicketStatus.Answered => new AnsweredTicketState(),
            Enums.TicketStatus.Closed => new ClosedTicketState(),
            _ => throw new InvalidOperationException("Unknown ticket status.")
        };
}