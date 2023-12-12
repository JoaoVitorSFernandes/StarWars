using StarWars.Interfaces.Base;
using StarWars.Models;

namespace StarWars.Interfaces.UserInterfaces;

public interface IUserManager : IBaseRepository<User>
{ 
    Task<User> SignIn(string email);
}
