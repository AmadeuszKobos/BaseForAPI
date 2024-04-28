using HomeAPI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeAPI.Repositories
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> GetUserByLoginAsync(string login)
    {
      return await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
    }
  }
}