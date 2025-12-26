using Microsoft.AspNetCore.Mvc;

namespace AT.UFTMS.WebAPI.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public sealed class TicketsQueryController(Application.Queries.Tickets.GetMyTickets.GetMyTicketsQuery query)
    : ControllerBase
{
    [HttpGet("my")]
    public IActionResult GetMyTickets([FromQuery] Application.Queries.Tickets.GetMyTickets.GetMyTicketsQueryRequest request)
    {
        return Ok(query.Execute(request));
    }
}