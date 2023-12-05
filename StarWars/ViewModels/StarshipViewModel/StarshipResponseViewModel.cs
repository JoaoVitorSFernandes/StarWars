using StarWars.Models;

namespace StarWars.ViewModels.StarshipViewModel;

public class StarshipResponseViewModel
{
    public long count { get; set; }
    public ICollection<Starship> results { get; set; }
}