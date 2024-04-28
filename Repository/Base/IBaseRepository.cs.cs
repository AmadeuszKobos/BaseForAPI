using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeAPI.Repositories
{
  public interface IBaseRepository<T> where T : class
  {
    IQueryable<T> GetAll();

    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetByIdAsync(int id);

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task AddOrUpdateAsync(int id, T entity);

    Task DeleteAsync(int id);
  }
}