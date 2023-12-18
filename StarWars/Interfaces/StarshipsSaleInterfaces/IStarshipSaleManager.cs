

using StarWars.ViewModels.SWAPIViewModel;

namespace StarWars.Interfaces.StarshipsSaleInterfaces;

public interface IStarshipSaleManager
{
    Task<IEnumerable<StarshipViewModel>> GetAll();
    Task<StarshipViewModel> GetByName(string starshipName);
    Task<IEnumerable<StarshipViewModel>> GetByModel(string starshipModel, int page, int pageSize);
    Task<IEnumerable<StarshipViewModel>> GetByManufacturer(string starshipManufacturer, int page, int pageSize);
}