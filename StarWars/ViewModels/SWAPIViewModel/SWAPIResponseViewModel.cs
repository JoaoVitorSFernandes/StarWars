namespace StarWars.ViewModels.SWAPIViewModel;

public class SWAPIResponseViewModel
{
    public long count { get; set; }
    public IEnumerable<StarshipViewModel> results { get; set; }
}