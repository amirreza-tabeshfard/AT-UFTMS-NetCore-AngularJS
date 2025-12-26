using Microsoft.AspNetCore.Mvc;

namespace AT.UFTMS.WebAPI.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController(Application.Abstractions.Services.IAuthService authService)
        : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login()
    {
        Guid userId = Guid.NewGuid();
        string username = "test-user";
        string token = authService.GenerateToken(userId, username);

        return Ok(new
        {
            token
        });
    }
}