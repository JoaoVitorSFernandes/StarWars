using System.Security.Claims;
using StarWars.Models;

namespace StarWars.Extensions;

public static class RoleClaimsExtensions
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        var result = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Patent)
        };
        result.AddRange(
            user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Slug))
        );

        return result;
    }
}