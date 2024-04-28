using HomeAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAPI.Services
{
  public interface IUserService
  {
    Task<User> GetUserByLogin(LoginVm loginVm);

    Task<User> GetUser(int userId);
  }
}