using Microsoft.AspNetCore.Mvc;

namespace AT.UFTMS.WebAPI.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TicketsController(Application.UseCases.Tickets.CreateTicket.CreateTicketUseCase createTicketUseCase,
                               Application.UseCases.Tickets.CloseTicket.CloseTicketUseCase closeTicketUseCase)
        : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] Application.DTOs.Requests.CreateTicketRequestDto request)
    {
        Application.DTOs.Responses.CreateTicketResponseDto ticketId = createTicketUseCase.Execute(request);
        return Ok(ticketId);
    }

    [HttpPost("{id}/close")]
    public IActionResult Close(Guid id)
    {
        closeTicketUseCase.Execute(id);
        return Ok();
    }
}