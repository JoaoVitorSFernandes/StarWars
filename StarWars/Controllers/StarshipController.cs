using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using StarWars.Models;
using StarWars.ViewModels.StarshipViewModel;

namespace StarWars.Controllers;

[ApiController]
public class StarshipController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public StarshipController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("v1/starship")]
    public async Task<IActionResult> GetAsync()
    {
        return Ok();
    }

    [HttpGet("v1/starship/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id)
    {
        return Ok();
    }

    [HttpPost("v1/starship")]
    public async Task<IActionResult> PostAsync()
    {
        return Created();
    }

    [HttpPut("v1/starship")]
    public async Task<IActionResult> PutAsync()
    {
        return Created();
    }

    [HttpDelete("v1/starship")]
    public async Task<IActionResult> DeleteAsync()
    {
        return Ok();
    }

    [HttpGet("v1/starship/forsale")]
    public async Task<IActionResult> GetStarshipForSaleAsync()
    {
        using HttpClient client = new HttpClient();

        var response = await client.GetAsync(_configuration.GetValue<string>("SWAPI:Connection"));
        var content = response.Content.ReadAsStringAsync().Result;
        var result = JsonSerializer.Deserialize<StarshipResponseViewModel>(content);

        return Ok(result);
    }

}