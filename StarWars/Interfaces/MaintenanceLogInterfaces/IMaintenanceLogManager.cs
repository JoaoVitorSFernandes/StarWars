using StarWars.Interfaces.Base;
using StarWars.Models;

namespace StarWars.Interfaces.MaintenanceLogInterfaces;

public interface IMaintenanceLogManager : IBaseRepository<MaintenanceLog>
{
    Task<IEnumerable<MissionLog>> GetByStat(string stat);
    Task<IEnumerable<MissionLog>> GetByDate(DateTime starDate, DateTime endDate);
}