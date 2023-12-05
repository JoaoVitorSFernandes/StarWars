using Microsoft.AspNetCore.Mvc;

namespace StarWars.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    //Melhorar Health Check
    [HttpGet("")]
    public IActionResult HealthCheck() => Ok();
}