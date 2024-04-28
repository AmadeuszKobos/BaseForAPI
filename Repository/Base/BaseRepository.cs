using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeAPI.Repositories
{
  public class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
      _context = context;
    }

    public IQueryable<T> GetAll()
    {
      return _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
      await _context.Set<T>().AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
      _context.Set<T>().Update(entity);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
      var entity = await GetByIdAsync(id);
      _context.Set<T>().Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task AddOrUpdateAsync(int id, T entity)
    {
      var existingEntity = await _context.Set<T>().FindAsync(id);
      if (existingEntity == null)
      {
        await AddAsync(entity);
      }
      else
      {
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
      }
    }
  }
}