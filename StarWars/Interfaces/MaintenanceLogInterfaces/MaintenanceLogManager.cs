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

    public Task<IEnumerable<MissionLog>> GetByDate(DateTime starDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MissionLog>> GetByStat(string stat)
    {
        throw new NotImplementedException();
    }
}