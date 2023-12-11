using StarWars.Interfaces.Base;
using StarWars.Models;

namespace StarWars.Interfaces.StarshipsInterfaces;

public interface IStarshipManager : IBaseRepository<Starship>
{   
    
    Task<IEnumerable<Starship>> GetByName(string name);
    Task<IEnumerable<Starship>> GetByModel(string model);
    Task<IEnumerable<Starship>> GetByManufacturer(string manufacturer);
}