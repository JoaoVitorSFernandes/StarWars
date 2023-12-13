using Microsoft.EntityFrameworkCore;
using StarWars.Data;
using StarWars.Interfaces.Base;
using StarWars.Interfaces.MaintenanceLogInterfaces;
using StarWars.Models;

namespace StarWars.Interfaces.MissionLogInterfaces;

public class MaintenanceLogManager : BaseRepository<MaintenanceLog>, IMaintenanceLogManager
{
    public MaintenanceLogManager(StarWarsDataContext context) : base(context)
    {
    }

    public async Task<IEnumerable<MaintenanceLog>> GetByDate(DateTime starDate, DateTime endDate)
        => await _context.MaintanenceLogs.AsNoTracking().Where(x => x.StarDate == starDate && x.EndDate == endDate).ToListAsync();

    public async Task<IEnumerable<MaintenanceLog>> GetByStat(string status)
        => await _context.MaintanenceLogs.AsNoTracking().Where(x => x.MaintenanceStatus == status)
                    .OrderByDescending(x => x.EndDate).ToListAsync();
}