using StarWars.Models;

namespace StarWars.Interfaces.Base;

public interface IBaseRepository<T> where T : class
{
    Task<T> GetById(int id);
    Task Insert(T entity);
    Task Update(int id, T entity);
    Task Delete(int id);
    Task<IEnumerable<T>> GetAll();
}
