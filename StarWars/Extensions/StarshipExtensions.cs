using StarWars.ViewModels.StarshipViewModel;

namespace StarWars.Extensions;

public static class StarshipExtensions
{
    public static bool IntFieldsIsValid(this EditorStarshipViewModel model)
    {
        if (Convert.ToInt32(model.passengers) < 0 ||
                Convert.ToInt32(model.costInCredits) < 0 ||
                    Convert.ToInt32(model.cargoCapacity) < 0)
            return false;

        return true;
    }
}