namespace AT.UFTMS.WebAPI.Application.DTOs.Requests;
public class CreateTicketRequestDto
{
    public string? Title { get; set; } = null!;

    public string? Description { get; set; } = null!;

    public Domain.Enums.TicketType Type { get; set; }

    public Domain.Enums.TicketPriority Priority { get; set; }
}