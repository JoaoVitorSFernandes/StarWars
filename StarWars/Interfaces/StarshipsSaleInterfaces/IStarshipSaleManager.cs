using StarWars.Models;
using StarWars.ViewModels.StarshipViewModel;

namespace StarWars.Interfaces.StarshipsSaleInterfaces;

public interface IStarshipSaleManager
{
    Task<IEnumerable<EditorStarshipViewModel>> GetAll();
    Task<IEnumerable<EditorStarshipViewModel>> GetByName(string starshipName, int page, int pageSize);
    Task<IEnumerable<EditorStarshipViewModel>> GetByModel(string starshipModel, int page, int pageSize);
    Task<IEnumerable<EditorStarshipViewModel>> GetByManufacturer(string starshipManufacturer, int page, int pageSize);
}