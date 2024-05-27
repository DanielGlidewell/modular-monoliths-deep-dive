using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace RiverBooks.Users;

public static class UserModuleExtensions 
{
  public static IServiceCollection AddUserModuleServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connection = config.GetConnectionString("UsersConnectionString");
    
    services.AddDbContext<UsersDbContext>(options => 
      options.UseSqlServer(connection));

    services.AddIdentityCore<ApplicationUser>()
      .AddEntityFrameworkStores<UsersDbContext>();

    logger.Information("User module services registered");

    return services;
  }
}
