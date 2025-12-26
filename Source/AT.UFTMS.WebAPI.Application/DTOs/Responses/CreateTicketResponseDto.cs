namespace AT.UFTMS.WebAPI.Application.DTOs.Responses;
public sealed class CreateTicketResponseDto(Guid ticketId)
{
    public Guid TicketId { get; } = ticketId;
}