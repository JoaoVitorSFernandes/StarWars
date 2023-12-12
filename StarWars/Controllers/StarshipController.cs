using Microsoft.AspNetCore.Mvc;
using StarWars.Models;
using StarWars.Extensions;
using StarWars.ViewModels;
using StarWars.ViewModels.StarshipViewModel;
using StarWars.Interfaces.StarshipsInterfaces;

namespace StarWars.Controllers;

[ApiController]
public class StarshipController : ControllerBase
{
    private readonly StarshipManager _starshipManager;

    [HttpGet("v1/starship/")]
    public async Task<IActionResult> GetAsync()
    {
        var starships = await _starshipManager.GetAll();

        if (starships == null)
            return NotFound(new ResultViewModel<Starship>("It looks like we couldn't find any starships in our registry."));

        return Ok(new ResultViewModel<IEnumerable<Starship>>(starships));
    }


    [HttpGet("v1/starship/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id)
    {
        var starship = await _starshipManager.GetById(id);

        if (starship == null)
            return NotFound(new ResultViewModel<Starship>("It looks like we couldn't find any starship in our registry."));

        return Ok(new ResultViewModel<Starship>(starship));
    }


    [HttpGet("v1/starship/name/{name}")]
    public async Task<IActionResult> GetByName(
        [FromRoute] string name,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 10)
    {
        var starships = await _starshipManager.GetByName(name, page, pageSize);

        if (starships == null)
            return NotFound(new ResultViewModel<Starship>("It looks like we couldn't find any starships in our registry."));

        return Ok(new ResultViewModel<IEnumerable<Starship>>(starships));
    }


    [HttpGet("v1/starship/model/{model}")]
    public async Task<IActionResult> GetByModel(
        [FromRoute] string model,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 10)
    {
        var starships = await _starshipManager.GetByModel(model, page, pageSize);

        if (starships == null)
            return NotFound(new ResultViewModel<Starship>("It looks like we couldn't find any starships in our registry."));

        return Ok(new ResultViewModel<IEnumerable<Starship>>(starships));
    }


    [HttpGet("v1/starship/manufacturer/{manufacturer}")]
    public async Task<IActionResult> GetByManufacturer(
        [FromRoute] string manufacturer,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 10)
    {
        var starships = await _starshipManager.GetByManufacturer(manufacturer, page, pageSize);

        if (starships == null)
            return NotFound(new ResultViewModel<Starship>("It looks like we couldn't find any starships in our registry."));

        return Ok(new ResultViewModel<IEnumerable<Starship>>(starships));
    }


    [HttpPost("v1/starship")]
    public async Task<IActionResult> PostAsync(
        [FromBody] EditorStarshipViewModel model)
    {

        if (!model.IntFieldsIsValid())
            return BadRequest("The input value cannot be negative.");

        var starship = new Starship(
            model.name,
            model.model,
            model.manufacturer,
            Convert.ToInt32(model.costInCredits),
            model.crew,
            Convert.ToInt32(model.passengers),
            Convert.ToInt32(model.cargoCapacity),
            model.starshipClass
        );

        await _starshipManager.Insert(starship);

        return Created($"v1/starship/{starship.Id}", new ResultViewModel<Starship>(starship));
    }


    [HttpPut("v1/starship/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromRoute] int id,
        [FromBody] EditorStarshipViewModel model)
    {
        if (!model.IntFieldsIsValid())
            return BadRequest("The input value cannot be negative.");

        var starship = await _starshipManager.GetById(id);

        starship.Name = model.name;
        starship.Model = model.model;
        starship.Manufacturer = model.manufacturer;
        starship.CostInCredits = Convert.ToInt32(model.costInCredits);
        starship.Passengers = Convert.ToInt32(model.passengers);
        starship.CargoCapacity = Convert.ToInt32(model.cargoCapacity);
        starship.StarshipClass = model.starshipClass;

        await _starshipManager.Update(id, starship);

        return Ok(new ResultViewModel<Starship>(starship));
    }


    [HttpDelete("v1/starship/{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] int id)
    {
        await _starshipManager.Delete(id);
        return Ok(new ResultViewModel<string>("Starship registration successfully deleted", null));
    }

}