using HomeAPI.DI;
using HomeAPI.Entity;
using HomeAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeAPI.Controllers.UserController
{
  [ApiController]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
  [Route("[controller]")]
  public class UserController : Controller
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpPost]
    [Route("GetToken"), AllowAnonymous]
    public async Task<IActionResult> GetToken(LoginVm loginVm)
    {
      var token = "";
      var user = new User();

      try
      {
        if (loginVm != null)
        {
          user = await _userService.GetUserByLogin(loginVm);
          token = TokenManager.GenerateToken(user);
        }

        return Ok(token);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("GetUser")]
    public async Task<IActionResult> GetUser(int id)
    {
      var user = await _userService.GetUser(id);

      if (user == null)
      {
        return NotFound();
      }

      return Ok(user);
    }
  }
}