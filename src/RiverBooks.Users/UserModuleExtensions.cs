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
    ILogger logger,
    List<System.Reflection.Assembly> mediatRAssemblies)
  {
    string? connection = config.GetConnectionString("UsersConnectionString");
    
    services.AddDbContext<UsersDbContext>(options => 
      options.UseSqlServer(connection));

    services.AddIdentityCore<ApplicationUser>()
      .AddEntityFrameworkStores<UsersDbContext>();

    // Because we're using MediatR, add the assembly to the list
    mediatRAssemblies.Add(typeof(UserModuleExtensions).Assembly);

    logger.Information("User module services registered");

    return services;
  }
}
