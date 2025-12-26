using Microsoft.AspNetCore.Mvc;

namespace AT.UFTMS.WebAPI.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HealthController 
    : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("API is running");
    }
}