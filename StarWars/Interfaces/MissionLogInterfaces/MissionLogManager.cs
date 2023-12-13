using Microsoft.EntityFrameworkCore;
using StarWars.Data;
using StarWars.Interfaces.Base;
using StarWars.Models;

namespace StarWars.Interfaces.MissionLogInterfaces;

public class MissionLogManager : BaseRepository<MissionLog>, IMissionLogManager
{
    public MissionLogManager(StarWarsDataContext context) : base(context)
    {
    }

    public override async Task<MissionLog> GetById(int id)
        => await _context.MissionLogs.AsNoTracking().Include(x => x.Users).Where(x => x.Id == id).FirstAsync();

    public async Task<IEnumerable<MissionLog>> GetByDate(DateTime starDate, DateTime endDate)
        => await _context.MissionLogs.AsNoTracking().Where(x => x.StarDate == starDate && x.EndDate == endDate).ToListAsync();

    public async Task<MissionLog> GetByName(string name)
        => await _context.MissionLogs.AsNoTracking().Where(x => x.MissionName == name).FirstAsync();

    public async Task<IEnumerable<MissionLog>> GetByStat(string stat)
        => await _context.MissionLogs.AsNoTracking().Where(x => x.MissionStats == stat)
                    .OrderByDescending(x => x.MissionName).ToListAsync();
}