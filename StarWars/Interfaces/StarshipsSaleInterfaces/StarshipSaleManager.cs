using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using StarWars.ViewModels.StarshipViewModel;

namespace StarWars.Interfaces.StarshipsSaleInterfaces;

public class StarshipSaleManager : IStarshipSaleManager
{
    private readonly IConfiguration _configuration;
    private readonly IMemoryCache _cache;

    public StarshipSaleManager(IConfiguration configuration, IMemoryCache cache)
    {
        _configuration = configuration;
        _cache = cache;
    }

    public async Task<IEnumerable<EditorStarshipViewModel>> GetAll()
    {
        var Starships = await _cache.GetOrCreateAsync("SWAPIStarshipResponse", entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
            return GetSWAPIStarships();
        });

        return Starships;
    }

    public async Task<IEnumerable<EditorStarshipViewModel>> GetByManufacturer(string starshipManufacturer, int page = 0, int pageSize = 10)
    {
        var starships = await GetAll();

        starships = starships.Where(x => x.manufacturer == starshipManufacturer)
                        .Skip(page * pageSize).Take(pageSize).ToList();

        return starships;
    }

    public async Task<IEnumerable<EditorStarshipViewModel>> GetByModel(string starshipModel, int page = 0, int pageSize = 10)
    {
        var starships = await GetAll();

        starships = starships.Where(x => x.model == starshipModel)
                        .Skip(page * pageSize).Take(pageSize).ToList();

        return starships;
    }

    public async Task<IEnumerable<EditorStarshipViewModel>> GetByName(string starshipName, int page = 0, int pageSize = 10)
    {
        var starships = await GetAll();

        starships = starships.Where(x => x.name == starshipName)
                        .Skip(page * pageSize).Take(pageSize).ToList();

        return starships;
    }

    private async Task<IEnumerable<EditorStarshipViewModel>> GetSWAPIStarships()
    {
        using HttpClient client = new HttpClient();

        var response = await client.GetAsync(_configuration.GetValue<string>("SWAPI:Connection"));
        var content = response.Content.ReadAsStringAsync().Result;
        var result = JsonSerializer.Deserialize<StarshipResponseViewModel>(content);

        return result.Starships;
    }

}