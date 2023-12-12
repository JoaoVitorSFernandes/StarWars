using SecureIdentity.Password;
using StarWars.Models;
using StarWars.ViewModels.UserViewModel;

namespace StarWars.Extensions;

public static class UserExtensions
{
    public static bool IsValid(this LoginViewModel model, User user)
    {
        if (user == null || !PasswordHasher.Verify(user.Password, model.Password))
            return false;

        return true;
    }
}