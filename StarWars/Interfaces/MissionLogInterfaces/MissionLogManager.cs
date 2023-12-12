using StarWars.Data;
using StarWars.Interfaces.Base;
using StarWars.Models;

namespace StarWars.Interfaces.MissionLogInterfaces;

public class MissionLogManager : BaseRepository<MissionLog>, IMissionLogManager
{
    public MissionLogManager(StarWarsDataContext context) : base(context)
    {
    }

    public Task<IEnumerable<MissionLog>> GetByDate(DateTime starDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MissionLog>> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MissionLog>> GetByStat(string stat)
    {
        throw new NotImplementedException();
    }
}