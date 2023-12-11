using StarWars.Models;

namespace StarWars.ViewModels.StarshipViewModel;

public class StarshipResponseViewModel
{
    public long count { get; set; }
    public IEnumerable<EditorStarshipViewModel> Starships { get; set; }
}