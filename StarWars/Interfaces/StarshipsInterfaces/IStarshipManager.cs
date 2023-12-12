using StarWars.Interfaces.Base;
using StarWars.Models;

namespace StarWars.Interfaces.StarshipsInterfaces;

public interface IStarshipManager : IBaseRepository<Starship>
{   
    
    Task<IEnumerable<Starship>> GetByName(string name, int page, int pageSize);
    Task<IEnumerable<Starship>> GetByModel(string model, int page, int pageSize);
    Task<IEnumerable<Starship>> GetByManufacturer(string manufacturer, int page, int pageSize);
}