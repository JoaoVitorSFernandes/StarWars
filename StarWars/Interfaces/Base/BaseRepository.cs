
using Microsoft.EntityFrameworkCore;
using StarWars.Data;
using StarWars.Models.Exceptions;

namespace StarWars.Interfaces.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly StarWarsDataContext _context;
    public BaseRepository(StarWarsDataContext context)
        => _context = context;

    public virtual async Task<IEnumerable<T>> GetAll()
        => await _context.Set<T>().AsNoTracking().ToListAsync();

    public virtual async Task<T> GetById(int id)
        => await _context.Set<T>().FindAsync(id);

    public async Task Insert(T entity)
    {
        try
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw new DatabaseException("EX_DB_INSERT - Erro in insert value in database");
        }
    }

    public async Task Update(int id, T entity)
    {
        try
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw new DatabaseException("EX_DB_UPDATE - Erro in update value in database");
        }
        
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);

        try
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw new DatabaseException("EX_DB_DELETE - Erro in delete value in database");
        }
    }
}
