using StarWars.Interfaces.Base;
using StarWars.Models;

namespace StarWars.Interfaces.MaintenanceLogInterfaces;

public interface IMaintenanceLogManager : IBaseRepository<MaintenanceLog>
{
    Task<IEnumerable<MaintenanceLog>> GetByStat(string status);
    Task<IEnumerable<MaintenanceLog>> GetByDate(DateTime starDate, DateTime endDate);
}