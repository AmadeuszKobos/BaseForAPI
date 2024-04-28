using HomeAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAPI.Repositories
{
  public interface IUserRepository : IBaseRepository<User>
  {
    Task<User?> GetUserByLoginAsync(string login);
  }
}