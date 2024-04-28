using HomeAPI.Entity;
using HomeAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAPI.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepo;

    public UserService(IUserRepository userRepository)
    {
      _userRepo = userRepository;
    }

    public async Task<User> GetUserByLogin(LoginVm loginVm)
    {
      return await _userRepo.GetUserByLoginAsync(loginVm.Login);
    }

    private string GenerateToken(User user)
    {
      return string.Empty;
    }

    public async Task<User> GetUser(int userId)
    {
      return await _userRepo.GetByIdAsync(userId);
    }
  }
}