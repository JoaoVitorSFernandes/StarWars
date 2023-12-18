using Microsoft.AspNetCore.Mvc;
using StarWars.Interfaces.MissionLogInterfaces;
using StarWars.Models;
using StarWars.ViewModels;
using StarWars.ViewModels.MissionLogViewModel;

namespace StarWars.Controllers;

[ApiController]
public class MissionLogController : ControllerBase
{
    private readonly IMissionLogManager _missionLogManager;

    public MissionLogController(IMissionLogManager missionLogManager)
    {
        _missionLogManager = missionLogManager;
    }

    [HttpGet("v1/missionlogs/")]
    public async Task<IActionResult> GetAll()
    {
        var missionLogs = await _missionLogManager.GetAll();

        if (missionLogs == null)
            return NotFound(new ResultViewModel<MissionLog>("It looks like we couldn't find any log mission in our registry."));

        return Ok(new ResultViewModel<IEnumerable<MissionLog>>(missionLogs));
    }


    [HttpGet("v1/missionlogs/{id:int}")]
    public async Task<IActionResult> GetById(
        [FromRoute] int id)
    {
        var missionLog = await _missionLogManager.GetById(id);

        if (missionLog == null)
            return NotFound(new ResultViewModel<MissionLog>("It looks like we couldn't find any log mission in our registry."));

        return Ok(new ResultViewModel<MissionLog>(missionLog));
    }


    [HttpGet("v1/missionlogs/name/{name}")]
    public async Task<IActionResult> GetByName(
        [FromRoute] string name)
    {
        var missionLog = await _missionLogManager.GetByName(name);

        if (missionLog == null)
            return NotFound(new ResultViewModel<MissionLog>("It looks like we couldn't find any log mission in our registry."));

        return Ok(new ResultViewModel<MissionLog>(missionLog));
    }


    [HttpGet("v1/missionlogs/stat/{stat}")]
    public async Task<IActionResult> GetByStat(
        [FromRoute] string stat)
    {
        var missionLog = await _missionLogManager.GetByStat(stat);

        if (missionLog == null)
            return NotFound(new ResultViewModel<MissionLog>("It looks like we couldn't find any log mission in our registry."));

        return Ok(new ResultViewModel<IEnumerable<MissionLog>>(missionLog));
    }


    [HttpGet("v1/missionlogs/date/")]
    public async Task<IActionResult> GetByDate(
        [FromQuery] DateTime starDate,
        [FromQuery] DateTime endDate)
    {
        var missionLog = await _missionLogManager.GetByDate(starDate, endDate);

        if (missionLog == null)
            return NotFound(new ResultViewModel<MissionLog>("It looks like we couldn't find any logs mission in our registry."));

        return Ok(new ResultViewModel<IEnumerable<MissionLog>>(missionLog));
    }


    [HttpPost("v1/missionlogs/")]
    public async Task<IActionResult> Post(
        [FromBody] EditorMissionLogViewModel model)
    {
        var missionLog = new MissionLog(
            model.MissionName,
            model.MissionStats,
            model.Subject,
            model.Report,
            model.StarDate,
            model.EndDate,
            model.StarshipId
        );
        missionLog.StarshipId = model.StarshipId;

        await _missionLogManager.Insert(missionLog);

        return Created($"v1/maintenances/{missionLog.Id}", new ResultViewModel<MissionLog>(missionLog));
    }


    [HttpPut("v1/missionlogs/{id:int}")]
    public async Task<IActionResult> Put(
        [FromRoute] int id,
        [FromBody] EditorMissionLogViewModel model)
    {
        var missionLog = await _missionLogManager.GetById(id);

        missionLog.MissionName = model.MissionName;
        missionLog.Subject = model.Subject;
        missionLog.Report = model.Report;
        missionLog.MissionStats = model.MissionStats;
        missionLog.StarDate = model.StarDate;
        missionLog.EndDate = model.EndDate;
        missionLog.Duration = missionLog.SetDuration(missionLog.StarDate, missionLog.EndDate);

        await _missionLogManager.Update(id, missionLog);

        return Ok(new ResultViewModel<MissionLog>(missionLog));
    }


    [HttpDelete("v1/missionlogs/{id:int}")]
    public async Task<IActionResult> Delete(
        [FromRoute] int id)
    {
        await _missionLogManager.Delete(id);
        return Ok();
    }
}