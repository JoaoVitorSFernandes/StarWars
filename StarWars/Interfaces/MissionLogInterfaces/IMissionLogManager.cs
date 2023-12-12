using StarWars.Interfaces.Base;
using StarWars.Models;

namespace StarWars.Interfaces.MissionLogInterfaces;

public interface IMissionLogManager : IBaseRepository<MissionLog>
{
    Task<IEnumerable<MissionLog>> GetByName(string name);
    Task<IEnumerable<MissionLog>> GetByStat(string stat);
    Task<IEnumerable<MissionLog>> GetByDate(DateTime starDate, DateTime endDate);
}