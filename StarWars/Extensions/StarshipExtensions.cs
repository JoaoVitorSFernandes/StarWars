using StarWars.ViewModels.StarshipViewModel;

namespace StarWars.Extensions;

public static class StarshipExtensions
{
    public static bool IntFieldsIsValid(this EditorStarshipViewModel model)
    {
        if (Convert.ToInt32(model.passengers) < 0 ||
                Convert.ToInt32(model.cost_in_credits) < 0 ||
                    Convert.ToInt32(model.cargo_capacity) < 0)
            return false;

        return true;
    }
}