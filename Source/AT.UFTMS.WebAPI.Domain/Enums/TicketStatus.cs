namespace AT.UFTMS.WebAPI.Domain.Enums;
public enum TicketStatus
    : SByte
{
    New = 1,

    InProgress = 2,

    Answered = 3,

    Closed = 4
}