using Microsoft.EntityFrameworkCore;
using StarWars.Data;
using StarWars.Interfaces.Base;
using StarWars.Models;

namespace StarWars.Interfaces.StarshipsInterfaces;

public class StarshipManager : BaseRepository<Starship>, IStarshipManager
{
    public StarshipManager(StarWarsDataContext context) : base(context)
    {
    }
    
    public override async Task<Starship> GetById(int id)
        => await _context.Starships.AsNoTracking().Where(x => x.Id == id)
                .Include(x => x.MissionLogs).Include(x => x.MaintenanceLogs).FirstAsync();

    public async Task<IEnumerable<Starship>> GetByManufacturer(string manufacturer,int page, int pageSize)
        => await _context.Starships.Where(x => x.Manufacturer == manufacturer).Skip(page * pageSize).Take(pageSize).ToListAsync();

    public async Task<IEnumerable<Starship>> GetByModel(string model, int page, int pageSize)
        => await _context.Starships.Where(x => x.Model == model).Skip(page * pageSize).Take(pageSize).ToListAsync();

    public async Task<IEnumerable<Starship>> GetByName(string name, int page, int pageSize)
        => await _context.Starships.Where(x => x.Name == name).Skip(page * pageSize).Take(pageSize).ToListAsync();

}