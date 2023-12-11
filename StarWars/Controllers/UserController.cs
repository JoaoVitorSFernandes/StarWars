using Microsoft.AspNetCore.Mvc;
using StarWars.Interfaces.UserInterfaces;

namespace StarWars.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager _userManager;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {

    }

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync()
    {

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync()
    {

    }

    [HttpPut]
    public async Task<IActionResult> PutAsync()
    {

    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync()
    {

    }
}