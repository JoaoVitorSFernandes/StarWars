using Microsoft.EntityFrameworkCore;
using StarWars.Data;
using StarWars.Interfaces.Base;
using StarWars.Models;

namespace StarWars.Interfaces.UserInterfaces;

public class UserManager : BaseRepository<User>, IUserManager
{
    public UserManager(StarWarsDataContext context) : base(context)
    {
    }

    public override async Task<User> GetById(int id)
        => await _context.Users.AsNoTracking().Where(x => x.Id == id)
                    .Include(x => x.Starships).Include(x => x.MissionLogs).FirstAsync();
}
