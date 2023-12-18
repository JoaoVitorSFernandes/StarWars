using Microsoft.AspNetCore.Mvc;
using StarWars.Interfaces.StarshipsSaleInterfaces;
using StarWars.Models;
using StarWars.ViewModels;

namespace StarWars.Controllers;

[ApiController]
public class StarshipsSaleController : ControllerBase
{
    private readonly IStarshipSaleManager _starshipSaleManager;

    public StarshipsSaleController(IStarshipSaleManager starshipSaleManager)
    {
        _starshipSaleManager = starshipSaleManager;
    }

    [HttpGet("v1/starshipssale/")]
    public async Task<IActionResult> GetAll()
    {
        var starshipsSale = await _starshipSaleManager.GetAll();

        if (starshipsSale == null)
            return NotFound(new ResultViewModel<dynamic>("We were unable to find Starships in our records"));

        return Ok(new ResultViewModel<dynamic>(starshipsSale));
    }

    [HttpGet("v1/starshipssale/name/{name}")]
    public async Task<IActionResult> GetByName(
        [FromRoute] string name)
    {
        var starshipSale = _starshipSaleManager.GetByName(name);

        if (starshipSale == null)
            return NotFound(new ResultViewModel<dynamic>("We were unable to find Starships in our records"));

        return Ok(new ResultViewModel<dynamic>(starshipSale));
    }

    [HttpGet("v1/starshipssale/model/{model}")]
    public async Task<IActionResult> GetByModel(
        [FromRoute] string model,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 10)
    {
        var starshipsSale = _starshipSaleManager.GetByModel(model, page, pageSize);

        if (starshipsSale == null)
            return NotFound(new ResultViewModel<dynamic>("We were unable to find Starships in our records"));

        return Ok(new ResultViewModel<dynamic>(starshipsSale));
    }

    [HttpGet("v1/starshipssale/manufacturer/{manufacturer}")]
    public async Task<IActionResult> GetByManufacturer(
        [FromRoute] string manufacturer,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 10)
    {
        var starshipsSale = _starshipSaleManager.GetByManufacturer(manufacturer, page, pageSize);

        if (starshipsSale == null)
            return NotFound(new ResultViewModel<dynamic>("We were unable to find Starships in our records"));

        return Ok(new ResultViewModel<dynamic>(starshipsSale));
    }

}