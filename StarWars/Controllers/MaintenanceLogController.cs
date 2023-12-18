using Microsoft.AspNetCore.Mvc;
using StarWars.Interfaces.MaintenanceLogInterfaces;
using StarWars.Interfaces.MissionLogInterfaces;
using StarWars.Models;
using StarWars.ViewModels;
using StarWars.ViewModels.MaintenanceLogViewModel;

namespace StarWars.Controllers;

[ApiController]
public class MaintenanceLogController : ControllerBase
{
    private readonly IMaintenanceLogManager _maintenanceLogManager;

    public MaintenanceLogController(IMaintenanceLogManager maintenanceLogManager)
    {
        _maintenanceLogManager = maintenanceLogManager;
    }

    [HttpGet("v1/maintenances/")]
    public async Task<IActionResult> GetAll()
    {
        var maintenances = await _maintenanceLogManager.GetAll();

        if (maintenances == null)
            return NotFound(new ResultViewModel<MaintenanceLog>("It looks like we couldn't find any logs maintenances in our registry."));

        return Ok(new ResultViewModel<IEnumerable<MaintenanceLog>>(maintenances));
    }

    [HttpGet("v1/maintenances/{id:int}")]
    public async Task<IActionResult> GetById(
        [FromRoute] int id)
    {
        var maintenance = await _maintenanceLogManager.GetById(id);

        if (maintenance == null)
            return NotFound(new ResultViewModel<MaintenanceLog>("It looks like we couldn't find any log maintenances in our registry."));

        return Ok(new ResultViewModel<MaintenanceLog>(maintenance));
    }


    [HttpGet("v1/maintenances/dates")]
    public async Task<IActionResult> GetByDate(
        [FromQuery] DateTime starDate,
        [FromQuery] DateTime endDate)
    {
        var maintenances = await _maintenanceLogManager.GetByDate(starDate, endDate);

        if (maintenances == null)
            return NotFound(new ResultViewModel<MaintenanceLog>("It looks like we couldn't find any logs maintenances in our registry."));

        return Ok(new ResultViewModel<IEnumerable<MaintenanceLog>>(maintenances));
    }


    [HttpGet("v1/maintenances/status/{status}")]
    public async Task<IActionResult> GetByStatus(
        [FromRoute] string status)
    {
        var maintenances = await _maintenanceLogManager.GetByStat(status);

        if (maintenances == null)
            return NotFound(new ResultViewModel<MaintenanceLog>("It looks like we couldn't find any logs maintenances in our registry."));

        return Ok(new ResultViewModel<IEnumerable<MaintenanceLog>>(maintenances));
    }


    [HttpPost("v1/maintenances/")]
    public async Task<IActionResult> Post(
        [FromBody] EditorMaintenanceViewModel model)
    {
        var maintenance = new MaintenanceLog(
            model.Subject,
            model.Report,
            model.MaintenanceStatus,
            model.StarDate,
            model.EndDate,
            model.StarshipId
        );
        maintenance.StarshipId = model.StarshipId;

        await _maintenanceLogManager.Insert(maintenance);

        return Created($"v1/maintenances/{maintenance.Id}", new ResultViewModel<MaintenanceLog>(maintenance));
    }


    [HttpPut("v1/maintenances/{id:int}")]
    public async Task<IActionResult> Put(
        [FromRoute] int id,
        [FromBody] EditorMaintenanceViewModel model)
    {
        var maintenance = await _maintenanceLogManager.GetById(id);

        maintenance.Subject = model.Subject;
        maintenance.Report = model.Report;
        maintenance.MaintenanceStatus = model.MaintenanceStatus;
        maintenance.StarDate = model.StarDate;
        maintenance.EndDate = model.EndDate;
        maintenance.Duration = maintenance.SetDuration(model.StarDate, model.EndDate);

        await _maintenanceLogManager.Update(id, maintenance);

        return Ok(new ResultViewModel<MaintenanceLog>(maintenance));
    }


    [HttpDelete("v1/maintenances/{id:int}")]
    public async Task<IActionResult> Delete(
        [FromRoute] int id)
    {
        await _maintenanceLogManager.Delete(id);
        return Ok(new ResultViewModel<string>("Maintenance registration successfully deleted", null));
    }

}