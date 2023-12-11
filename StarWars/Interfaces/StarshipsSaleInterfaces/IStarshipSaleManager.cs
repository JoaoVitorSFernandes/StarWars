using StarWars.Models;
using StarWars.ViewModels.StarshipViewModel;

namespace StarWars.Interfaces.StarshipsSaleInterfaces;

public interface IStarshipSaleManager
{
    Task<IEnumerable<EditorStarshipViewModel>> GetAll();
    Task<IEnumerable<EditorStarshipViewModel>> GetByName(string starshipName);
    Task<IEnumerable<EditorStarshipViewModel>> GetByModel(string starshipModel);
    Task<IEnumerable<EditorStarshipViewModel>> GetByManufacturer(string starshipManufacturer);
}