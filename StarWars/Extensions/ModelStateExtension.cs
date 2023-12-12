using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StarWars.Extensions;

public static class ModelStateExtension
{
    public static List<string> GetErros(this ModelStateDictionary modelState)
    {
        var result = new List<string>();

        foreach(var item in modelState.Values)
            result.AddRange(item.Errors.Select(erro => erro.ErrorMessage));

        return result;
    }
}