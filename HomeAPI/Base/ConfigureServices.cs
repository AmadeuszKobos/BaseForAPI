using HomeAPI.Repositories;
using HomeAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace HomeAPI.DI
{
  public static partial class ConfigureServices
  {
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
      RegisterCustomDependencies(services);

      return services;
    }



    private static void RegisterCustomDependencies(IServiceCollection services)
    {
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IUserService, UserService>();
    }
  }
}